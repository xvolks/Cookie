using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapObstacleUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6051;
        public override uint MessageID { get { return ProtocolId; } }

        public List<MapObstacle> Obstacles;

        public MapObstacleUpdateMessage()
        {
        }

        public MapObstacleUpdateMessage(
            List<MapObstacle> obstacles
        )
        {
            Obstacles = obstacles;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Obstacles.Count());
            foreach (var current in Obstacles)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObstacles = reader.ReadShort();
            Obstacles = new List<MapObstacle>();
            for (short i = 0; i < countObstacles; i++)
            {
                MapObstacle type = new MapObstacle();
                type.Deserialize(reader);
                Obstacles.Add(type);
            }
        }
    }
}