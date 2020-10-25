using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 226;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public double MapId = 0;
        public List<HouseInformations> Houses;
        public List<GameRolePlayActorInformations> Actors;
        public List<InteractiveElement> InteractiveElements;
        public List<StatedElement> StatedElements;
        public List<MapObstacle> Obstacles;
        public List<FightCommonInformations> Fights;
        public bool HasAggressiveMonsters = false;
        public FightStartingPositions FightStartPositions;

        public MapComplementaryInformationsDataMessage()
        {
        }

        public MapComplementaryInformationsDataMessage(
            short subAreaId,
            double mapId,
            List<HouseInformations> houses,
            List<GameRolePlayActorInformations> actors,
            List<InteractiveElement> interactiveElements,
            List<StatedElement> statedElements,
            List<MapObstacle> obstacles,
            List<FightCommonInformations> fights,
            bool hasAggressiveMonsters,
            FightStartingPositions fightStartPositions
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteDouble(MapId);
            writer.WriteShort((short)Houses.Count());
            foreach (var current in Houses)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)Actors.Count());
            foreach (var current in Actors)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)InteractiveElements.Count());
            foreach (var current in InteractiveElements)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)StatedElements.Count());
            foreach (var current in StatedElements)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)Obstacles.Count());
            foreach (var current in Obstacles)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)Fights.Count());
            foreach (var current in Fights)
            {
                current.Serialize(writer);
            }
            writer.WriteBoolean(HasAggressiveMonsters);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            MapId = reader.ReadDouble();
            var countHouses = reader.ReadShort();
            Houses = new List<HouseInformations>();
            for (short i = 0; i < countHouses; i++)
            {
                var housestypeId = reader.ReadShort();
                HouseInformations type = new HouseInformations();
                type.Deserialize(reader);
                Houses.Add(type);
            }
            var countActors = reader.ReadShort();
            Actors = new List<GameRolePlayActorInformations>();
            for (short i = 0; i < countActors; i++)
            {
                var actorstypeId = reader.ReadShort();
                GameRolePlayActorInformations type = new GameRolePlayActorInformations();
                type.Deserialize(reader);
                Actors.Add(type);
            }
            var countInteractiveElements = reader.ReadShort();
            InteractiveElements = new List<InteractiveElement>();
            for (short i = 0; i < countInteractiveElements; i++)
            {
                var interactiveElementstypeId = reader.ReadShort();
                InteractiveElement type = new InteractiveElement();
                type.Deserialize(reader);
                InteractiveElements.Add(type);
            }
            var countStatedElements = reader.ReadShort();
            StatedElements = new List<StatedElement>();
            for (short i = 0; i < countStatedElements; i++)
            {
                StatedElement type = new StatedElement();
                type.Deserialize(reader);
                StatedElements.Add(type);
            }
            var countObstacles = reader.ReadShort();
            Obstacles = new List<MapObstacle>();
            for (short i = 0; i < countObstacles; i++)
            {
                MapObstacle type = new MapObstacle();
                type.Deserialize(reader);
                Obstacles.Add(type);
            }
            var countFights = reader.ReadShort();
            Fights = new List<FightCommonInformations>();
            for (short i = 0; i < countFights; i++)
            {
                FightCommonInformations type = new FightCommonInformations();
                type.Deserialize(reader);
                Fights.Add(type);
            }
            HasAggressiveMonsters = reader.ReadBoolean();
            FightStartPositions = new FightStartingPositions();
            FightStartPositions.Deserialize(reader);
        }
    }
}