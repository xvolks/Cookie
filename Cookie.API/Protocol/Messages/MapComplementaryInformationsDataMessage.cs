using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 226;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public uint MapId { get; set; }
        public List<HouseInformations> Houses { get; set; }
        public List<GameRolePlayActorInformations> Actors { get; set; }
        public List<InteractiveElement> InteractiveElements { get; set; }
        public List<StatedElement> StatedElements { get; set; }
        public List<MapObstacle> Obstacles { get; set; }
        public List<FightCommonInformations> Fights { get; set; }
        public bool HasAggressiveMonsters { get; set; }
        public FightStartingPositions FightStartPositions { get; set; }
        public MapComplementaryInformationsDataMessage() { }

        public MapComplementaryInformationsDataMessage( ushort SubAreaId, uint MapId, List<HouseInformations> Houses, List<GameRolePlayActorInformations> Actors, List<InteractiveElement> InteractiveElements, List<StatedElement> StatedElements, List<MapObstacle> Obstacles, List<FightCommonInformations> Fights, bool HasAggressiveMonsters, FightStartingPositions FightStartPositions ){
            this.SubAreaId = SubAreaId;
            this.MapId = MapId;
            this.Houses = Houses;
            this.Actors = Actors;
            this.InteractiveElements = InteractiveElements;
            this.StatedElements = StatedElements;
            this.Obstacles = Obstacles;
            this.Fights = Fights;
            this.HasAggressiveMonsters = HasAggressiveMonsters;
            this.FightStartPositions = FightStartPositions;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteDouble(MapId);
			writer.WriteShort((short)Houses.Count);
			foreach (var x in Houses)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Actors.Count);
			foreach (var x in Actors)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)InteractiveElements.Count);
			foreach (var x in InteractiveElements)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)StatedElements.Count);
			foreach (var x in StatedElements)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Obstacles.Count);
			foreach (var x in Obstacles)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Fights.Count);
			foreach (var x in Fights)
			{
				x.Serialize(writer);
			}
            writer.WriteBoolean(HasAggressiveMonsters);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            MapId = (uint)reader.ReadDouble();
            var HousesCount = reader.ReadShort();
            Houses = new List<HouseInformations>();
            for (var i = 0; i < HousesCount; i++)
            {
                HouseInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Houses.Add(objectToAdd);
            }
            var ActorsCount = reader.ReadShort();
            Actors = new List<GameRolePlayActorInformations>();
            for (var i = 0; i < ActorsCount; i++)
            {
                GameRolePlayActorInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Actors.Add(objectToAdd);
            }
            var InteractiveElementsCount = reader.ReadShort();
            InteractiveElements = new List<InteractiveElement>();
            for (var i = 0; i < InteractiveElementsCount; i++)
            {
                InteractiveElement objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                InteractiveElements.Add(objectToAdd);
            }
            var StatedElementsCount = reader.ReadShort();
            StatedElements = new List<StatedElement>();
            for (var i = 0; i < StatedElementsCount; i++)
            {
                var objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                StatedElements.Add(objectToAdd);
            }
            var ObstaclesCount = reader.ReadShort();
            Obstacles = new List<MapObstacle>();
            for (var i = 0; i < ObstaclesCount; i++)
            {
                var objectToAdd = new MapObstacle();
                objectToAdd.Deserialize(reader);
                Obstacles.Add(objectToAdd);
            }
            var FightsCount = reader.ReadShort();
            Fights = new List<FightCommonInformations>();
            for (var i = 0; i < FightsCount; i++)
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
