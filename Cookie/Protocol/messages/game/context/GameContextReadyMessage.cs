using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextReadyMessage : NetworkMessage
    {
        public const uint ProtocolId = 6071;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;

        public GameContextReadyMessage()
        {
        }

        public GameContextReadyMessage(
            double mapId
        )
        {
            MapId = mapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
        }
    }
}