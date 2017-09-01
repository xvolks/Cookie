namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.Interactive;
    using System.Collections.Generic;
    using Utils.IO;

    public class MapObstacleUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6051;
        public override ushort MessageID => ProtocolId;
        public List<MapObstacle> Obstacles { get; set; }

        public MapObstacleUpdateMessage(List<MapObstacle> obstacles)
        {
            Obstacles = obstacles;
        }

        public MapObstacleUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Obstacles.Count);
            for (var obstaclesIndex = 0; obstaclesIndex < Obstacles.Count; obstaclesIndex++)
            {
                var objectToSend = Obstacles[obstaclesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var obstaclesCount = reader.ReadUShort();
            Obstacles = new List<MapObstacle>();
            for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
            {
                var objectToAdd = new MapObstacle();
                objectToAdd.Deserialize(reader);
                Obstacles.Add(objectToAdd);
            }
        }

    }
}
