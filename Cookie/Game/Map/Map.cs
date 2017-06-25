using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cookie.API.Datacenter;
using Cookie.API.Game.Entity;
using Cookie.API.Game.Map;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Gamedata.D2p.Elements;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Messages.Game.Interactive;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.Core;
using Cookie.Game.Map.Elements;
using Cookie.Gamedata;
using Cookie.Utils;
using IMap = Cookie.API.Game.Map.IMap;
using Pathfinder = Cookie.API.Game.World.Pathfinding.Pathfinder;

namespace Cookie.Game.Map
{
    public class Map : IMap
    {
        private readonly DofusClient _client;
        
        public Dictionary<int, IInteractiveElement> Doors { get; private set; }
        public Dictionary<int, IStatedElement> StatedElements { get; private set; }
        public int WorldId => ObjectDataManager.Instance.Get<MapPosition>(Id).WorldMap;
        public IMapData Data { get; private set; }
        public int Id => ((API.Gamedata.D2p.Map)Data).Id;
        public int X => ObjectDataManager.Instance.Get<MapPosition>(Id).PosX;
        public int Y => ObjectDataManager.Instance.Get<MapPosition>(Id).PosY;
        public Dictionary<int, IInteractiveElement> InteractiveElements { get; private set; }
        public int SubAreaId { get; private set; }
        public int MapChange { get; set; }

        public object CheckLock { get; set; }

        public string Position { get; set; }

        public string Zone { get; set; }

        public Dictionary<int, IUsableElement> UsableElements
        {
            get
            {
                var usableElements = new Dictionary<int, IUsableElement>();
                foreach (var element in InteractiveElements)
                {
                    var interactiveElements = (Elements.InteractiveElement) element.Value;
                    if (interactiveElements.EnabledSkills.Count < 1) continue;
                    foreach (var layer in ((API.Gamedata.D2p.Map) Data).Layers)
                    {
                        foreach (var cell in layer.Cells)
                        {
                            foreach (var layerElement in cell.Elements)
                            {
                                if (!(layerElement is GraphicalElement l)) continue;
                                if (l.Identifier == interactiveElements.Id)
                                    usableElements.Add((int) interactiveElements.Id,
                                        new UsableElement(cell.CellId, interactiveElements,
                                            interactiveElements.EnabledSkills));
                            }
                        }
                    }
                }
                return usableElements;
            }
        }

        public IEntity Character => Entities.FirstOrDefault(e => e.Id == (int) _client.Account.Character.Id);
        public List<IEntity> Entities { get; private set; }

        public Map(DofusClient client)
        {
            _client = client;
            Data = null;
            Doors = new Dictionary<int, IInteractiveElement>();
            Entities = new List<IEntity>();
            InteractiveElements = new Dictionary<int, IInteractiveElement>();
            StatedElements = new Dictionary<int, IStatedElement>();
            SubAreaId = 0;
            CheckLock = new object();
        }


        public bool CanGatherElement(int id, int distance)
        {
            return distance <= 1 && distance >= 0;
        }

        public bool ChangeMap(MapDirectionEnum direction)
        {
            var neighbourId = -1;
            var num2 = -1;
            if (direction == MapDirectionEnum.North)
            {
                neighbourId = ((API.Gamedata.D2p.Map) Data).TopNeighbourId;
                num2 = 64;
            }
            else if (direction == MapDirectionEnum.South)
            {
                neighbourId = ((API.Gamedata.D2p.Map)Data).BottomNeighbourId;
                num2 = 4;
            }
            else if (direction == MapDirectionEnum.East)
            {
                neighbourId = ((API.Gamedata.D2p.Map)Data).RightNeighbourId;
                num2 = 1;
            }
            else if (direction == MapDirectionEnum.West)
            {
                neighbourId = ((API.Gamedata.D2p.Map)Data).LeftNeighbourId;
                num2 = 16;
            }

            if ((num2 != -1) && (neighbourId >= 0))
            {
                var cellId = _client.Account.Character.CellId;
                if ((((API.Gamedata.D2p.Map) Data).Cells[cellId].MapChangeData & num2) > 0)
                {
                    LaunchChangeMap(neighbourId);
                    return true;
                }
                var list = new List<int>();
                var num4 = ((API.Gamedata.D2p.Map) Data).Cells.Count - 1;

                for (var i = 0; i < num4; i++)
                {
                    if (((((API.Gamedata.D2p.Map)Data).Cells[i].MapChangeData & num2) > 0) && NothingOnCell(i))
                        list.Add(i);
                }

                while (list.Count > 0)
                {
                    var randomCellId = list[Randomize.GetRandomNumber(0, list.Count)];
                    if (MoveToCell(randomCellId))
                    {
                        MapChange = neighbourId;
                        if ((((API.Gamedata.D2p.Map)Data).Cells[randomCellId].MapChangeData & num2) > 0)
                        {
                            LaunchChangeMap(neighbourId);
                            return true;
                        }
                        return true;
                    }
                    list.Remove(randomCellId);
                }
            }
            return false;
        }

        public bool MoveToCell(int cellId)
        {
            var path =
                (new API.Game.World.Pathfinding.Pathfinder(_client.Account.Character.Map)).FindPath(
                    _client.Account.Character.CellId, cellId);
            if (path == null)
                return false;
            var serverMovement = MapMovementAdapter.GetServerMovement(path);

            _client.Send(
                new GameMapMovementRequestMessage(serverMovement.Select<uint, short>(ui => (short) ui).ToList(), Id));

            var timeTowait = MapMovementAdapter.GetPathVelocity(path,
                path.Cells.Count < 4
                    ? MapMovementAdapter.MovementTypeEnum.Walking
                    : MapMovementAdapter.MovementTypeEnum.Running);

            Thread.Sleep(timeTowait * 2);
            ConfirmMove();
            return true;
        }

        public void ConfirmMove()
        {
            _client.Send(new GameMapMovementConfirmMessage());
        }

        public bool MoveToDoor(int cellId)
        {
            return MoveToCellWithDistance(cellId, 1, true);
        }

        public bool MoveToElement(int id, int maxDistance)
        {
            var element = StatedElements.GetValueOrNull(id);
            return element != null && MoveToCellWithDistance((int) element.CellId, maxDistance, true);
        }

        public bool MoveToSecureElement(int id)
        {
            var element = StatedElements.GetValueOrNull(id);
            return element != null && MoveToCellWithDistance((int) element.CellId, 1, true);
        }

        public bool NoEntitiesOnCell(int cellId)
        {
            lock (CheckLock)
            {
                var selectedEntity = Entities.FirstOrDefault(e => e.CellId == cellId);
                return selectedEntity == null;
            }
        }

        public bool NothingOnCell(int cellId)
        {
            return Data.IsWalkable(cellId) && NoEntitiesOnCell(cellId);
        }

        public void UseElement(int id, int skillId)
        {
            //Thread.Sleep(Randomize.GetRandomNumber(150, 200));
            Randomize.RunBetween(() =>
            {
                _client.Send(new InteractiveUseRequestMessage((uint)id, (uint)skillId));
            }, 150, 200);
           
        }

        public bool MoveToCellWithDistance(int cellId, int maxDistance, bool bool1)
        {
            MovementPath path = null;
            var savDistance = -1;
            var characterPoint = new MapPoint(_client.Account.Character.CellId);
            var targetPoint = new MapPoint(cellId);
            foreach (var point in GetListPointAtGoodDistance(characterPoint, targetPoint, maxDistance))
            {
                Pathfinder pathFinding = null;
                if (targetPoint.DistanceToCell(point) > maxDistance ||
                    targetPoint.X != point.X && targetPoint.Y != point.Y)
                    continue;
                var distance = characterPoint.DistanceTo(point);
                if (savDistance != -1 && distance >= savDistance)
                    continue;
                if (bool1)
                {
                    if (Data.IsWalkable(point.CellId))
                        goto Label_00A8;
                    continue;
                }
                if (!NothingOnCell(point.CellId))
                    continue;
                Label_00A8:
                pathFinding = new Pathfinder(_client.Account.Character.Map);
                var path2 = pathFinding.FindPath(_client.Account.Character.CellId, point.CellId);
                if (path2 == null) continue;
                path = path2;
                savDistance = distance;
            }
            if (path == null)
                return false;
            var serverMovement = MapMovementAdapter.GetServerMovement(path);
            _client.Send(new GameMapMovementRequestMessage(serverMovement.Select(ui => (short) ui).ToList(), Id));
            var timeTowait = MapMovementAdapter.GetPathVelocity(path,
                path.Cells.Count < 4
                    ? MapMovementAdapter.MovementTypeEnum.Walking
                    : MapMovementAdapter.MovementTypeEnum.Running);
            Thread.Sleep(timeTowait * 2);
            ConfirmMove();
            return true;
        }

        private IEnumerable<MapPoint> GetListPointAtGoodDistance(MapPoint characterPoint, MapPoint elementPoint, int weaponRange)
        {
            var list = new List<MapPoint>();
            var num = -1;
            var direction = 1;
            while (true)
            {
                var i = 0;
                while (i < weaponRange)
                {
                    i += 1;
                    var nearestCellInDirection = elementPoint.GetNearestCellInDirection(direction, i);
                    if (!nearestCellInDirection.IsInMap() ||
                        !_client.Account.Character.Map.Data.IsWalkable(nearestCellInDirection.CellId)) continue;
                    var num4 = characterPoint.DistanceToCell(nearestCellInDirection);
                    if (num == -1 || num >= num4)
                    {
                        if (num4 < num)
                            list.Clear();
                        num = num4;
                        list.Add(nearestCellInDirection);
                    }
                    break;
                }
                direction = direction + 2;
                if (direction > 7)
                    return list;
            }
        }

        private void LaunchChangeMap(int mapId)
        {

            _client.Send(new ChangeMapMessage(mapId));
        }

        public void RemoveEntity(int id)
        {
            lock (this.CheckLock)
            {
                var removeEntity = Entities.FirstOrDefault(e => e.Id == id);
                if (removeEntity != null)
                    Entities.Remove(removeEntity);
            }
        }

        public void UpdateEntity(GameMapMovementMessage message)
        {
            lock (this.CheckLock)
            {
                    var clientMovement = MapMovementAdapter.GetClientMovement(message.KeyMovements.Select<short, uint>(s => (uint)s).ToList());
                    var entity = Entities.FirstOrDefault(e => e.Id == message.ActorId);
                    if (entity != null)
                        ((Entity.Entity)Entities[Entities.IndexOf(entity)]).CellId = clientMovement.CellEnd.CellId;
            }
        }

        public void UpdateEntity(TeleportOnSameMapMessage message)
        {
            lock (this.CheckLock)
            {
                var entity = Entities.FirstOrDefault(e => e.Id == message.TargetId);
                if (entity != null)
                    ((Entity.Entity)Entities[Entities.IndexOf(entity)]).CellId = message.CellId;
            }
        }

        public void AddActor(GameRolePlayShowActorMessage message)
        {
            lock (this.CheckLock)
            {
                IEntity entity = new Entity.Entity((int) message.Informations.ContextualId, message.Informations.Disposition.CellId);
                Entities.Add(entity);
            }
        }

        public void UpdateInteractive(InteractiveElementUpdatedMessage message)
        {
            lock (this.CheckLock)
            {
                if (!message.InteractiveElement.OnCurrentMap) return;
                var interactiveElement = InteractiveElements.GetValueOrNull(message.InteractiveElement.ElementId);
                if (interactiveElement != null)
                    InteractiveElements.Remove((int)interactiveElement.Id);
                InteractiveElements.Add(message.InteractiveElement.ElementId,
                    new Elements.InteractiveElement((uint) message.InteractiveElement.ElementId,
                        message.InteractiveElement.ElementTypeId, message.InteractiveElement.EnabledSkills.ToList(),
                        message.InteractiveElement.DisabledSkills.ToList()));
            }
        }

        public void UpdateInteractive(InteractiveMapUpdateMessage message)
        {
            lock (this.CheckLock)
            {
                foreach (var interactiveElementDofus in message.InteractiveElements)
                {
                    if (!interactiveElementDofus.OnCurrentMap) continue;
                    var selectedInteractiveElement = InteractiveElements.GetValueOrNull(interactiveElementDofus.ElementId);
                    if (selectedInteractiveElement != null)
                        InteractiveElements.Remove((int)selectedInteractiveElement.Id);
                    InteractiveElements.Add(interactiveElementDofus.ElementId,
                        new Elements.InteractiveElement((uint) interactiveElementDofus.ElementId,
                            interactiveElementDofus.ElementTypeId, interactiveElementDofus.EnabledSkills.ToList(),
                            interactiveElementDofus.DisabledSkills.ToList()));
                }
            }
        }

        public void ParseMapComplementaryInformationsDataMessage(MapComplementaryInformationsDataMessage message)
        {
            lock (CheckLock)
            {
                SubAreaId = message.SubAreaId;
                Data = MapsManager.FromId(message.MapId);
                var subArea =
                    ObjectDataManager.Instance.Get<SubArea>(SubAreaId);
                var mapName = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                    .Get<Area>(subArea.AreaId).NameId);
                var subAreaName = FastD2IReader.Instance.GetText(subArea.NameId);
                Position = $"[{X}, {Y}]";
                Zone = $"{mapName} ({subAreaName})";
                Entities.Clear();
                Entities.AddRange(
                    message.Actors.Select<GameRolePlayActorInformations, IEntity>(
                        a => new Entity.Entity((int) a.ContextualId, a.Disposition.CellId)));
                StatedElements.Clear();
                foreach (var statedElementDofus in message.StatedElements)
                    if (!StatedElements.ContainsKey(statedElementDofus.ElementId) || !statedElementDofus.OnCurrentMap)
                        StatedElements.Add(statedElementDofus.ElementId,
                            new StatedElement(statedElementDofus.ElementCellId,
                                (uint) statedElementDofus.ElementId, statedElementDofus.ElementState));
                InteractiveElements.Clear();
                Doors.Clear();
                foreach (var element in message.InteractiveElements)
                {
                    if (!element.OnCurrentMap) continue;
                    InteractiveElements.Add(element.ElementId,
                        new InteractiveElement((uint) element.ElementId, element.ElementTypeId,
                            element.EnabledSkills.ToList(), element.DisabledSkills.ToList()));
                    var interactiveElement = element;
                    var listDoorSkillId = new List<int>(new[] {184, 183, 187, 198, 114});
                    var listDoorTypeId = new List<int>(new[] {-1, 128, 168, 16});
                    if (!listDoorTypeId.Contains(interactiveElement.ElementTypeId) ||
                        interactiveElement.EnabledSkills.Count <= 0 ||
                        !listDoorSkillId.Contains((int) interactiveElement.EnabledSkills[0].SkillId)) continue;
                    foreach (var layer in ((API.Gamedata.D2p.Map) Data).Layers)
                    foreach (var cell in layer.Cells)
                    foreach (var layerElement in cell.Elements)
                        if (layerElement is GraphicalElement l)
                            if (l.Identifier == interactiveElement.ElementId &&
                                !Doors.ContainsKey(cell.CellId))
                                Doors.Add(cell.CellId,
                                    new InteractiveElement((uint) element.ElementId,
                                        element.ElementTypeId, element.EnabledSkills.ToList(),
                                        element.DisabledSkills.ToList()));
                }
            }
        }

        public void UpdateStatedElement(StatedElementUpdatedMessage message)
        {
            lock (this.CheckLock)
            {
                var statedElement = StatedElements.GetValueOrNull(message.StatedElement.ElementId);
                if (statedElement != null)
                {
                    StatedElements.Remove((int)statedElement.Id);
                    StatedElements.Add(message.StatedElement.ElementId,
                        new Elements.StatedElement((uint)message.StatedElement.ElementCellId,
                            (uint)message.StatedElement.ElementId, (uint)message.StatedElement.ElementState));
                }
                    
            }
        }

        public void UpdateStatedElement(StatedMapUpdateMessage message)
        {
            lock (this.CheckLock)
            {
                foreach (var statedElementDofus in message.StatedElements)
                {
                    if (!statedElementDofus.OnCurrentMap) continue;
                    var selectedStatedElement = StatedElements.GetValueOrNull(statedElementDofus.ElementId);
                    if (selectedStatedElement != null)
                    {
                        StatedElements.Remove((int)selectedStatedElement.Id);
                        StatedElements.Add(statedElementDofus.ElementId,
                            new Elements.StatedElement((uint)statedElementDofus.ElementCellId,
                                (uint)statedElementDofus.ElementId, (uint)statedElementDofus.ElementState));
                    }
                        
                }
            }
        }
    }
}