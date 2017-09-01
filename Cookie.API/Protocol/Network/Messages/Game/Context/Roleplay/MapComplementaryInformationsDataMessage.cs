using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Types.Game.House;
using Cookie.API.Protocol.Network.Types.Game.Interactive;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 226;

        public MapComplementaryInformationsDataMessage(ushort subAreaId, int mapId, List<HouseInformations> houses,
            List<GameRolePlayActorInformations> actors, List<InteractiveElement> interactiveElements,
            List<StatedElement> statedElements, List<MapObstacle> obstacles, List<FightCommonInformations> fights,
            bool hasAggressiveMonsters, FightStartingPositions fightStartPositions)
        {
            SubAreaId = subAreaId;
            MapId = mapId;
            Houses = houses;
            Actors = actors;
            InteractiveElements = interactiveElements;
            StatedElements = statedElements;
            Obstacles = obstacles;
            Fights = fights;
            HasAggressiveMonsters = hasAggressiveMonsters;
            FightStartPositions = fightStartPositions;
        }

        public MapComplementaryInformationsDataMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public int MapId { get; set; }
        public List<HouseInformations> Houses { get; set; }
        public List<GameRolePlayActorInformations> Actors { get; set; }
        public List<InteractiveElement> InteractiveElements { get; set; }
        public List<StatedElement> StatedElements { get; set; }
        public List<MapObstacle> Obstacles { get; set; }
        public List<FightCommonInformations> Fights { get; set; }
        public bool HasAggressiveMonsters { get; set; }
        public FightStartingPositions FightStartPositions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteInt(MapId);
            writer.WriteShort((short) Houses.Count);
            for (var housesIndex = 0; housesIndex < Houses.Count; housesIndex++)
            {
                var objectToSend = Houses[housesIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Actors.Count);
            for (var actorsIndex = 0; actorsIndex < Actors.Count; actorsIndex++)
            {
                var objectToSend = Actors[actorsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) InteractiveElements.Count);
            for (var interactiveElementsIndex = 0;
                interactiveElementsIndex < InteractiveElements.Count;
                interactiveElementsIndex++)
            {
                var objectToSend = InteractiveElements[interactiveElementsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) StatedElements.Count);
            for (var statedElementsIndex = 0; statedElementsIndex < StatedElements.Count; statedElementsIndex++)
            {
                var objectToSend = StatedElements[statedElementsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Obstacles.Count);
            for (var obstaclesIndex = 0; obstaclesIndex < Obstacles.Count; obstaclesIndex++)
            {
                var objectToSend = Obstacles[obstaclesIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Fights.Count);
            for (var fightsIndex = 0; fightsIndex < Fights.Count; fightsIndex++)
            {
                var objectToSend = Fights[fightsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteBoolean(HasAggressiveMonsters);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            MapId = reader.ReadInt();
            var housesCount = reader.ReadUShort();
            Houses = new List<HouseInformations>();
            for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<HouseInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Houses.Add(objectToAdd);
            }
            var actorsCount = reader.ReadUShort();
            Actors = new List<GameRolePlayActorInformations>();
            for (var actorsIndex = 0; actorsIndex < actorsCount; actorsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Actors.Add(objectToAdd);
            }
            var interactiveElementsCount = reader.ReadUShort();
            InteractiveElements = new List<InteractiveElement>();
            for (var interactiveElementsIndex = 0;
                interactiveElementsIndex < interactiveElementsCount;
                interactiveElementsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                InteractiveElements.Add(objectToAdd);
            }
            var statedElementsCount = reader.ReadUShort();
            StatedElements = new List<StatedElement>();
            for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
            {
                var objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                StatedElements.Add(objectToAdd);
            }
            var obstaclesCount = reader.ReadUShort();
            Obstacles = new List<MapObstacle>();
            for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
            {
                var objectToAdd = new MapObstacle();
                objectToAdd.Deserialize(reader);
                Obstacles.Add(objectToAdd);
            }
            var fightsCount = reader.ReadUShort();
            Fights = new List<FightCommonInformations>();
            for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
            {
                var objectToAdd = new FightCommonInformations();
                objectToAdd.Deserialize(reader);
                Fights.Add(objectToAdd);
            }
            HasAggressiveMonsters = reader.ReadBoolean();
            FightStartPositions = new FightStartingPositions();
            FightStartPositions.Deserialize(reader);
        }
    }
}