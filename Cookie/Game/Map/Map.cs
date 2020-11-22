﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Datacenter;
using Cookie.API.Game.Entity;
using Cookie.API.Game.Map;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Gamedata.D2p.Elements;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.API.Utils.Extensions;
using Cookie.Core;
using Cookie.Game.Entity;
using Cookie.Game.Map.Elements;
using DofusMapControl;
using IMap = Cookie.API.Game.Map.IMap;
using InteractiveElement = Cookie.Game.Map.Elements.InteractiveElement;
using Npc = Cookie.Game.Entity.Npc;
using StatedElement = Cookie.Game.Map.Elements.StatedElement;

namespace Cookie.Game.Map
{
    public class Map : IMap
    {
        private readonly IAccount _account;

        public Map(IAccount account)
        {
            _account = account;
            Data = null;
            Doors = new Dictionary<int, IInteractiveElement>();
            Entities = new List<IEntity>();
            Monsters = new List<IMonsterGroup>();
            Npcs = new List<INpc>();
            Players = new List<IPlayer>();
            Merchants = new List<IMerchant>();
            Resources = new List<IResource>();
            InteractiveElements = new Dictionary<int, IInteractiveElement>();
            StatedElements = new Dictionary<int, IStatedElement>();
            SubAreaId = 0;
            CheckLock = new object();

            ((Account) account).MainForm.mapControl.CellClicked += MapControl_CellClicked;

            Attach();
        }
        public Map(IMapData data)
        {
            _account = null;
            Data = data;
            Doors = new Dictionary<int, IInteractiveElement>();
            Entities = new List<IEntity>();
            Monsters = new List<IMonsterGroup>();
            Npcs = new List<INpc>();
            Players = new List<IPlayer>();
            Merchants = new List<IMerchant>();
            Resources = new List<IResource>();
            InteractiveElements = new Dictionary<int, IInteractiveElement>();
            StatedElements = new Dictionary<int, IStatedElement>();
            SubAreaId = 0;
            CheckLock = new object();
        }
        #region Variables
        public object CheckLock { get; set; }
        public string Position { get; set; }
        public string Zone { get; set; }
        public List<IEntity> Entities { get; }
        public List<IMonsterGroup> Monsters { get; }
        public List<INpc> Npcs { get; }
        public List<IPlayer> Players { get; }
        public List<IMerchant> Merchants { get; }
        public List<IResource> Resources { get; }
        public Dictionary<int, IInteractiveElement> Doors { get; }
        public Dictionary<int, IStatedElement> StatedElements { get; }
        public int WorldId => ObjectDataManager.Instance.Get<MapPosition>(Convert.ToUInt32(Id)).WorldMap;
        public IMapData Data { get; private set; }
        public double Id => ((API.Gamedata.D2p.Map) Data).Id;
        public int X => ObjectDataManager.Instance.Get<MapPosition>(Convert.ToUInt32(Id)).PosX;
        public int Y => ObjectDataManager.Instance.Get<MapPosition>(Convert.ToUInt32(Id)).PosY;
        public Dictionary<int, IInteractiveElement> InteractiveElements { get; }
        public int SubAreaId { get; private set; }
        public int MapChange { get; set; }
        public Dictionary<int, IUsableElement> UsableElements
        {
            get
            {
                var usableElements = new Dictionary<int, IUsableElement>();
                foreach (var element in InteractiveElements.ToList())
                {
                    var interactiveElements = (InteractiveElement) element.Value;
                    if (interactiveElements.EnabledSkills.Count < 1) continue;
                    foreach (var layer in ((API.Gamedata.D2p.Map) Data).Layers)
                    foreach (var cell in layer.Cells)
                    foreach (var layerElement in cell.Elements)
                    {
                        if (!(layerElement is GraphicalElement l)) continue;
                        if (l.Identifier == interactiveElements.Id)
                            usableElements.Add((int) interactiveElements.Id,
                                new UsableElement(cell.CellId, interactiveElements,
                                    interactiveElements.EnabledSkills));
                    }
                }
                return usableElements;
            }
        }
        public IEntity Character => Entities.FirstOrDefault(e => e.Id == (int) _account.Character.Id);
        #endregion
        public bool CanGatherElement(int id, int distance)
        {
            return distance <= 1 && distance >= 0;
        }

        public void LaunchAttack(double removeMob = 0)
        {
            if (removeMob != 0)
                Monsters.Remove(Monsters.Find(x => x.Id == removeMob));
            Logger.Default.Log($"LaunchAttack");
            var monsterGroup = Monsters.FirstOrDefault();
            if (monsterGroup == null)
                return;
            int maxLevel = monsterGroup.GroupLevel;
            foreach(var monster in Monsters)
            {
                if (monster.GroupLevel > maxLevel)
                    monsterGroup = monster;
            }
            if (_account.Character.CellId == monsterGroup.CellId)
            {
                _account.Network.SendToServer(new GameRolePlayAttackMonsterRequestMessage(monsterGroup.Id));
                return;
            }
            var movement = MoveToCell(monsterGroup.CellId);
            void MovementFinished(object s, CellMovementEventArgs e)
            {
                movement.MovementFinished -= MovementFinished;
                if (e.Sucess)
                {
                    if (e.EndCell == monsterGroup.CellId)
                    {
                        Task.Delay(250).Wait();
                        _account.Network.SendToServer(new GameRolePlayAttackMonsterRequestMessage(monsterGroup.Id));
                        Logger.Default.Log($"Launching Attack");
                    }
                    else
                    {
                        Logger.Default.Log($"Movement returned Success but endCell[{e.EndCell}] doens't match with monsterCell[{monsterGroup.CellId}]. Perhaps listening to wrong movement?");
                        LaunchAttack(monsterGroup.Id);
                    }
                }
                /*else
                {
                    Logger.Default.Log($"Could not move closer to {monsterGroup.GroupName}.");
                    _account.PerformAction(_account.Character.PathManager.DoAction, 1000);
                }
                */
            }

            movement.MovementFinished += MovementFinished;
            movement.PerformMovement();
        }

        public void LaunchAttackByCellId(ushort cellId)
        {
            if (cellId > 559) return;
            var movement = MoveToCell(cellId);
            movement.MovementFinished += (sender, e) =>
            {
                if (!e.Sucess) return;
                var monsterGroup = Monsters.First(g => g.CellId == cellId);
                if (monsterGroup != null)
                    _account.Network.SendToServer(new GameRolePlayAttackMonsterRequestMessage(monsterGroup.Id));
            };
            movement.PerformMovement();
        }

        public void LaunchAttackByMonsterGroup(IMonsterGroup monsterGroup)
        {
            if (monsterGroup == null) return;
            var movement = MoveToCell(monsterGroup.CellId);
            movement.MovementFinished += (sender, e) =>
            {
                if (e.Sucess)
                    _account.Network.SendToServer(new GameRolePlayAttackMonsterRequestMessage(monsterGroup.Id));
            };
            movement.PerformMovement();
        }

        public IMapChangement ChangeMap(MapDirectionEnum direction)
        {
            var neighbourId = -1;
            var num2 = -1;
            switch (direction)
            {
                case MapDirectionEnum.North:
                    neighbourId = ((API.Gamedata.D2p.Map) Data).TopNeighbourId;
                    num2 = 64;
                    break;
                case MapDirectionEnum.South:
                    neighbourId = ((API.Gamedata.D2p.Map) Data).BottomNeighbourId;
                    num2 = 4;
                    break;
                case MapDirectionEnum.East:
                    neighbourId = ((API.Gamedata.D2p.Map) Data).RightNeighbourId;
                    num2 = 1;
                    break;
                case MapDirectionEnum.West:
                    neighbourId = ((API.Gamedata.D2p.Map) Data).LeftNeighbourId;
                    num2 = 16;
                    break;
            }

            if (num2 == -1 || neighbourId < 0) return null;
            var list = new List<int>();
            var num4 = ((API.Gamedata.D2p.Map) Data).Cells.Count - 1;

            for (var i = 0; i < num4; i++)
                if ((((API.Gamedata.D2p.Map) Data).Cells[i].MapChangeData & num2) > 0 && NothingOnCell(i) && i != _account.Character.CellId)
                    list.Add(i);
            var randomCellId = list[Randomize.GetRandomNumber(0, list.Count)];
            var move = MoveToCell(randomCellId);
            if (move == null)
                throw new Exception("ICellMovement cannot be null");
            return new MapChangement(_account, move, neighbourId);
        }

        public ICellMovement MoveToCell(int cellId)
        {
            var path = new Pathfinder(_account.Character.Map).FindPath(_account.Character.CellId, cellId);
            var move = new CellMovement(_account, path);
            return move;
        }

        public ICellMovement MoveToDoor(int cellId)
        {
            return MoveToCellWithDistance(cellId, 1, true);
        }

        public ICellMovement MoveToElement(int id, int maxDistance)
        {
            var element = StatedElements.GetValue(id);
            if (element == null)
                throw new Exception($"could not find element[{id}]");
            return MoveToCellWithDistance((int)element.CellId, maxDistance, true);
        }

        public ICellMovement MoveToSecureElement(int id)
        {
            var element = StatedElements.GetValue(id);
            return element != null ? MoveToCellWithDistance((int) element.CellId, 1, true) : null;
        }

        public void PlayerFightRequest(string playerName)
        {
            Logger.Default.Log("Appel de fonction fight!");
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
            _account.PerformAction( () => _account.Network.SendToServer(new InteractiveUseRequestMessage((uint) id, (uint) skillId)), 100);
        }

        public ICellMovement MoveToCellWithDistance(int cellId, int maxDistance, bool bool1)
        {
            MovementPath path = null;
            var savDistance = -1;
            var characterPoint = new MapPoint(_account.Character.CellId);
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
                pathFinding = new Pathfinder(_account.Character.Map);
                var path2 = pathFinding.FindPath(_account.Character.CellId, point.CellId);
                if (path2 == null) continue;
                path = path2;
                savDistance = distance;
            }
            if (path == null)
                return null;
            var move = new CellMovement(_account, path);
            return move;
        }

        // <summary>Movement was a success</summary>
        public event EventHandler<MovementConfirmed> MovementConfirmed;
        // <summary>Movement failed</summary>
        public event EventHandler MovementFailed;
        // <summary>Movement started</summary>
        public event Action<GameMapMovementMessage> MapMovement;

        public event EventHandler<MapChangedEventArgs> MapChanged;

        private void MapControl_CellClicked(MapControl control, MapCell cell, MouseButtons buttons, bool hold)
        {
            if (buttons != MouseButtons.Left) return;
            // If data is null, no map have been entered, the bot is not running.
            if (Data is null) throw new BotNotRunningException();

            var mov = MoveToCell(cell.Id);
            mov.MovementFinished += (sender, e) =>
            {
                if (e.Sucess)
                    Logger.Default.Log($"Déplacement réussi sur la cell: {cell.Id}");
            };
            mov.PerformMovement();
            control.Invalidate(cell);
        }

        private void Attach()
        {
            _account.Network.RegisterPacket<CurrentMapMessage>(HandleCurrentMapMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<CurrentMapInstanceMessage>(HandleCurrentMapInstanceMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(
                HandleMapComplementaryInformationsDataMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<MapComplementaryInformationsDataInHouseMessage>(
                HandleMapComplementaryInformationsDataInHouseMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<MapComplementaryInformationsWithCoordsMessage>(
                HandleMapComplementaryInformationsWithCoordsMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<GameRolePlayShowActorMessage>(HandleGameRolePlayShowActorMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<GameContextRemoveElementMessage>(HandleGameContextRemoveElementMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<TeleportOnSameMapMessage>(HandleTeleportOnSameMapMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<GameMapMovementMessage>(HandleGameMapMovementMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<GameMapMovementConfirmMessage>(HandleGameMapMovementConfirmMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<InteractiveElementUpdatedMessage>(HandleInteractiveElementUpdatedMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<StatedElementUpdatedMessage>(HandleStatedElementUpdatedMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<InteractiveMapUpdateMessage>(HandleInteractiveMapUpdateMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<StatedMapUpdateMessage>(HandleStatedMapUpdateMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<GameMapNoMovementMessage>(HandleGameMapNoMovementMessage,
                MessagePriority.VeryHigh);
        }

        private IEnumerable<MapPoint> GetListPointAtGoodDistance(MapPoint characterPoint, MapPoint elementPoint,
            int weaponRange)
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
                        !_account.Character.Map.Data.IsWalkable(nearestCellInDirection.CellId)) continue;
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
                direction += + 2;
                if (direction > 7)
                    return list;
            }
        }

        private void LaunchChangeMap(int mapId)
        {
            _account.Network.SendToServer(new ChangeMapMessage(mapId, false));
        }

        private void HandleCurrentMapMessage(IAccount account, CurrentMapMessage message)
        {
            _account.Character.Status = CharacterStatus.None;
            _account.Character.MapId = message.MapId;
            MapPosition tmp = ObjectDataManager.Instance.Get<MapPosition>((uint)message.MapId);
            _account.Character.PosX = tmp.PosX;
            _account.Character.PosY = tmp.PosY;
            _account.Network.SendToServer(new MapInformationsRequestMessage(message.MapId));
            MapChange = -1;
        }

        private void HandleCurrentMapInstanceMessage(IAccount account, CurrentMapInstanceMessage message)
        {
            HandleCurrentMapMessage(account, message);
        }

        private void HandleGameContextRemoveElementMessage(IAccount account, GameContextRemoveElementMessage message)
        {
            lock (CheckLock)
            {
                Players.Remove(Players.Find(p => p.Id == message.Id));
                Monsters.Remove(Monsters.Find(x => x.Id == message.Id));
                Entities.Remove(Entities.Find(x => x.Id == message.Id));
                Resources.Remove(Resources.Find(x => x.Id == message.Id));

                UpdateMapControl();
            }
        }

        private void HandleGameMapMovementConfirmMessage(IAccount account, GameMapMovementConfirmMessage message)
        {
            //the player has finished moving
            Console.WriteLine($"GameMapMovementConfirmMessage");
            if (account.Character.Map.MapChange != -1)
            {
                var mapChangeData = ((API.Gamedata.D2p.Map) Data).Cells[account.Character.CellId].MapChangeData;
                if (mapChangeData != 0)
                {
                    var neighbourId = account.Character.Map.MapChange;
                    if (neighbourId == -2)
                    {
                        if ((mapChangeData & 64) > 0)
                            neighbourId = ((API.Gamedata.D2p.Map) Data).TopNeighbourId;
                        if ((mapChangeData & 16) > 0)
                            neighbourId = ((API.Gamedata.D2p.Map) Data).LeftNeighbourId;
                        if ((mapChangeData & 4) > 0)
                            neighbourId = ((API.Gamedata.D2p.Map) Data).BottomNeighbourId;
                        if ((mapChangeData & 1) > 0)
                            neighbourId = ((API.Gamedata.D2p.Map) Data).RightNeighbourId;
                    }
                    if (neighbourId >= 0)
                        LaunchChangeMap(neighbourId);
                }
            }
            OnMovementConfirmed();
        }

        private void HandleGameMapMovementMessage(IAccount account, GameMapMovementMessage message)
        {
            // The player has moved.
            Console.WriteLine($"GameMapMovementMessage[{message.ActorId}]CharacterId[{account.Character.Id}]");
            lock (CheckLock)
            {
                var clientMovement = MapMovementAdapter.GetClientMovement(message.KeyMovements.Select(s => (uint)s).ToList());
                if (message.ActorId == account.Character.Id)
                    account.Character.CellId = clientMovement.CellEnd.CellId;
                else if (Players.Find(x => x.Id == message.ActorId) != null)
                    Players.Find(x => x.Id == message.ActorId).CellId = clientMovement.CellEnd.CellId;
                else if (Entities.Find(x => x.Id == message.ActorId) != null)
                    Entities.Find(x => x.Id == message.ActorId).CellId = clientMovement.CellEnd.CellId;
                else if (Monsters.Find(x => x.Id == message.ActorId) != null)
                    Monsters.Find(x => x.Id == message.ActorId).CellId = clientMovement.CellEnd.CellId;
                //else
                    //Logger.Default.Log($"ActorId[{message.ActorId}] not found");
                    //Monsters.Add(new MonsterGroup(new GroupMonsterStaticInformations(), message.ActorId, clientMovement.CellEnd.CellId));
            }

            UpdateMapControl();

            OnMapMovement(message);
        }

        private void HandleGameRolePlayShowActorMessage(IAccount account, GameRolePlayShowActorMessage message)
        {
            lock (CheckLock)
            {
                AddActors(new List<GameRolePlayActorInformations> {message.Informations});

                UpdateMapControl();
            }
        }

        private void HandleInteractiveElementUpdatedMessage(IAccount account, InteractiveElementUpdatedMessage message)
        {
            lock (CheckLock)
            {
                if (!message.InteractiveElement.OnCurrentMap) return;
                var interactiveElement = InteractiveElements.GetValue(message.InteractiveElement.ElementId);
                if (interactiveElement != null)
                    InteractiveElements.Remove((int) interactiveElement.Id);
                InteractiveElements.Add(message.InteractiveElement.ElementId,
                    new InteractiveElement((uint) message.InteractiveElement.ElementId,
                        message.InteractiveElement.ElementTypeId, message.InteractiveElement.EnabledSkills.ToList(),
                        message.InteractiveElement.DisabledSkills.ToList()));
            }
            if(account.Character.PathManager.Launched)
                account.PerformAction(account.Character.PathManager.DoAction, 150);
        }

        private void HandleInteractiveMapUpdateMessage(IAccount account, InteractiveMapUpdateMessage message)
        {
            lock (CheckLock)
            {
                foreach (var interactiveElementDofus in message.InteractiveElements)
                {
                    if (!interactiveElementDofus.OnCurrentMap) continue;
                    var selectedInteractiveElement = InteractiveElements.GetValue(interactiveElementDofus.ElementId);
                    if (selectedInteractiveElement != null)
                        InteractiveElements.Remove((int) selectedInteractiveElement.Id);
                    InteractiveElements.Add(interactiveElementDofus.ElementId,
                        new InteractiveElement((uint) interactiveElementDofus.ElementId,
                            interactiveElementDofus.ElementTypeId, interactiveElementDofus.EnabledSkills.ToList(),
                            interactiveElementDofus.DisabledSkills.ToList()));
                }
            }
        }

        private void HandleMapComplementaryInformationsDataInHouseMessage(IAccount account,
            MapComplementaryInformationsDataInHouseMessage message)
        {
            HandleMapComplementaryInformationsDataMessage(account, message);
        }

        private void HandleMapComplementaryInformationsDataMessage(IAccount account,
            MapComplementaryInformationsDataMessage message)
        {
            lock (CheckLock)
            {
                SubAreaId = message.SubAreaId;
                Data = MapsManager.FromId(message.MapId);
                var subArea = ObjectDataManager.Instance.Get<SubArea>(SubAreaId);
                var mapName =
                    FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Area>(subArea.AreaId).NameId);
                var subAreaName = FastD2IReader.Instance.GetText(subArea.NameId);
                Position = $"[{X}, {Y}]";
                Zone = $"{mapName} ({subAreaName})";
                Entities.Clear();
                Monsters.Clear();
                Npcs.Clear();
                Players.Clear();
                Resources.Clear();
                AddActors(message.Actors);
                StatedElements.Clear();
                foreach (var statedElementDofus in message.StatedElements)
                    if (!StatedElements.ContainsKey(statedElementDofus.ElementId) && statedElementDofus.OnCurrentMap)
                        StatedElements.Add(statedElementDofus.ElementId,
                            new StatedElement(statedElementDofus.ElementCellId, (uint) statedElementDofus.ElementId,
                                statedElementDofus.ElementState));
                InteractiveElements.Clear();
                Doors.Clear();
                foreach (var element in message.InteractiveElements)
                {
                    if (!element.OnCurrentMap) continue;
                    InteractiveElements.Add(element.ElementId,
                        new InteractiveElement((uint)element.ElementId, element.ElementTypeId,
                            element.EnabledSkills.ToList(), element.DisabledSkills.ToList()));
                    var interactiveElement = element;
                    var listDoorSkillId = new List<int>(new[] { 184, 183, 187, 198, 114 });
                    var listDoorTypeId = new List<int>(new[] { -1, 128, 168, 16 });
                    if (!listDoorTypeId.Contains(interactiveElement.ElementTypeId) ||
                        interactiveElement.EnabledSkills.Count <= 0 ||
                        !listDoorSkillId.Contains((int)interactiveElement.EnabledSkills[0].SkillId)) continue;
                    foreach (var layer in ((API.Gamedata.D2p.Map)Data).Layers)
                        foreach (var cell in layer.Cells)
                            foreach (var layerElement in cell.Elements)
                                if (layerElement is GraphicalElement graphicalElement)
                                    if (graphicalElement.Identifier == interactiveElement.ElementId &&
                                        !Doors.ContainsKey(cell.CellId))
                                        Doors.Add(cell.CellId,
                                            new InteractiveElement((uint)element.ElementId, element.ElementTypeId,
                                                element.EnabledSkills.ToList(), element.DisabledSkills.ToList()));
                }
                //foreach (var usableElement in _account.Character.Map.UsableElements)
                //    foreach (var interactiveElement in _account.Character.Map.InteractiveElements.Values)
                //    {
                //        if (usableElement.Value.Element.Id != interactiveElement.Id ||
                //            !interactiveElement.IsUsable) continue;
                //        if (!_account.Character.Map.NoEntitiesOnCell(usableElement.Value.CellId))
                //            continue;
                //        Resources.Add(new Resource(usableElement.Value.CellId, usableElement.Value.Element.Id, usableElement.Value.Element.TypeId));
                //        Entities.Add(new Entity.Entity(usableElement.Value.Element.Id, usableElement.Value.CellId));
                //    }
            }

            UpdateMapControl();

            OnMapChanged();
        }

        private void UpdateMapControl()
        {
            /////// MAPCONTROL ///////
            if(Data != null)
            {
                var tmp = MapsManager.FromId(Id);
                tmp.Cells.ForEachWithIndex((cellData, index) =>
                {
                    var cell = ((Account)_account).MainForm.mapControl.GetCell(index);
                    cell.Text = cell.Id.ToString();
                    if (cellData.Los)
                        cell.State = CellState.NonWalkable;
                    if (cellData.Mov)
                        cell.State = CellState.Walkable;
                });

                foreach (var npc in Npcs)
                {
                    ((Account) _account).MainForm.mapControl.Entities.Remove(
                        ((Account) _account).MainForm.mapControl.Entities.Find(m => m.ID == npc.Id));
                    ((Account) _account).MainForm.mapControl.Entities.Add(new MapEntity(npc.Id, npc.CellId, Color.Yellow));
                }

                foreach (var g in Monsters)
                {
                    ((Account) _account).MainForm.mapControl.Entities.Remove( ((Account) _account).MainForm.mapControl.Entities.Find(m => m.ID == g.Id) );
                    ((Account) _account).MainForm.mapControl.Entities.Add(new MapEntity(g.Id, g.CellId, Color.Red));
                }

                foreach (var p in Players)
                {
                    ((Account) _account).MainForm.mapControl.Entities.Remove(
                        ((Account) _account).MainForm.mapControl.Entities.Find(m => m.ID == p.Id));
                    ((Account) _account).MainForm.mapControl.Entities.Add(new MapEntity(p.Id, p.CellId, Color.Blue));
                }
                foreach (var r in Resources)
                {
                    ((Account)_account).MainForm.mapControl.Entities.Remove(
                        ((Account)_account).MainForm.mapControl.Entities.Find(m => m.ID == r.Id));
                    ((Account)_account).MainForm.mapControl.Entities.Add(new MapEntity(r.Id, r.CellId, Color.Green));
                }
                ((Account) _account).MainForm.mapControl.Invalidate();

            }
            /////// MAPCONTROL ///////
        }

        private void AddActors(IEnumerable<GameRolePlayActorInformations> actors)
        {
            foreach (var actor in actors)
            {
                if (actor is GameRolePlayGroupMonsterInformations monster)
                {
                    Monsters.Add(new MonsterGroup(monster.StaticInfos,
                        monster.ContextualId, monster.Disposition.CellId));
                    continue;
                }
                if (actor is GameRolePlayNpcInformations npc)
                {
                    Npcs.Add(new Npc(npc.Disposition.CellId, npc.ContextualId, npc.NpcId));
                    continue;
                }
                if (actor is GameRolePlayCharacterInformations player)
                {
                    if (player.ContextualId == this._account.Character.Id)
                        this._account.Character.CellId = player.Disposition.CellId;
                    Players.Add(new Player(actor.Disposition.CellId, player.ContextualId, player.Name));
                    continue;
                }
                if (actor is GameRolePlayMerchantInformations merchant)
                {
                    Merchants.Add(new Merchant(merchant.Disposition.CellId, merchant.ContextualId, (byte)merchant.SellType,
                        merchant.Name));
                    continue;
                }
                Entities.Add(new Entity.Entity(actor.ContextualId, actor.Disposition.CellId));
            }
        }

        private void HandleMapComplementaryInformationsWithCoordsMessage(IAccount account,
            MapComplementaryInformationsWithCoordsMessage message)
        {
            HandleMapComplementaryInformationsDataMessage(account, message);
        }

        private void HandleStatedElementUpdatedMessage(IAccount account, StatedElementUpdatedMessage message)
        {
            lock (CheckLock)
            {
                if (!message.StatedElement.OnCurrentMap) return;
                var statedElement = StatedElements.GetValue(message.StatedElement.ElementId);
                if (statedElement != null)
                    StatedElements.Remove((int) statedElement.Id);
                StatedElements.Add(message.StatedElement.ElementId,
                    new StatedElement(message.StatedElement.ElementCellId, (uint) message.StatedElement.ElementId,
                        message.StatedElement.ElementState));
            }
        }

        private void HandleStatedMapUpdateMessage(IAccount account, StatedMapUpdateMessage message)
        {
            lock (CheckLock)
            {
                foreach (var statedElementDofus in message.StatedElements)
                {
                    if (!statedElementDofus.OnCurrentMap) continue;
                    var selectedStatedElement = StatedElements.GetValue(statedElementDofus.ElementId);
                    if (selectedStatedElement != null)
                        StatedElements.Remove((int) selectedStatedElement.Id);
                    StatedElements.Add(statedElementDofus.ElementId,
                        new StatedElement(statedElementDofus.ElementCellId, (uint) statedElementDofus.ElementId,
                            statedElementDofus.ElementState));
                }
            }
        }

        private void HandleTeleportOnSameMapMessage(IAccount account, TeleportOnSameMapMessage message)
        {
            lock (CheckLock)
            {
                foreach(var x in Entities)
                {
                    if (x.CellId == message.TargetId)
                        x.CellId = message.CellId;
                }
                foreach(var x in Players)
                {
                    if (x.CellId == message.TargetId)
                        x.CellId = message.CellId;
                }
            }
        }

        private void HandleGameMapNoMovementMessage(IAccount account, GameMapNoMovementMessage message)
        {
            Logger.Default.Log("Erreur lors du déplacement sur cellX : " + message.CellX + "cellY : " + message.CellY);
            OnMovementFailed();
        }
        private void OnMapMovement(GameMapMovementMessage message)
        {
            MapMovement?.Invoke(message);
        }

        private void OnMovementConfirmed()
        {
            MovementConfirmed?.Invoke(_account, new MovementConfirmed(true));
            _account.Character.Status = CharacterStatus.None;
        }

        private void OnMovementFailed()
        {
            MovementFailed?.Invoke(_account, null);
        }

        private void OnMapChanged()
        {
            MapChanged?.Invoke(_account, new MapChangedEventArgs(Id));
            ((Account)_account).MainForm.UpdateMapLabel($"{X},{Y}");
        }
        #region ChangeMap Button Events
        private bool WaitingForMapChange { get; set; }
        public void ChangeMapButton(MapDirectionEnum direction)
        {
            if (Data is null) Logger.Default.Log($"Bot currently not running",LogMessageType.Error);
            if (WaitingForMapChange) return;
            WaitingForMapChange = true;
            IMapChangement mapChangement = ChangeMap(direction);
            mapChangement.ChangementFinished += MapChangement_ChangementFinished;
            mapChangement.PerformChangement();
        }

        private void MapChangement_ChangementFinished(object sender, MapChangementFinishedEventArgs e)
        {
            if (e.Success)
                Logger.Default.Log($"Map Change was succefull. New Map [{X},{Y}]");
            else
                Logger.Default.Log($"Error trying to changemap.");
            WaitingForMapChange = false;
        }
        #endregion
    }
}