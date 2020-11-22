using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapObstacleUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6051;

        public override ushort MessageID => ProtocolId;

        public List<MapObstacle> Obstacles { get; set; }
        public MapObstacleUpdateMessage() { }

        public MapObstacleUpdateMessage( List<MapObstacle> Obstacles ){
            this.Obstacles = Obstacles;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Obstacles.Count);
			foreach (var x in Obstacles)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObstaclesCount = reader.ReadShort();
            Obstacles = new List<MapObstacle>();
            for (var i = 0; i < ObstaclesCount; i++)
            {
                var objectToAdd = new MapObstacle();
                objectToAdd.Deserialize(reader);
                Obstacles.Add(objectToAdd);
            }
        }
    }
}
