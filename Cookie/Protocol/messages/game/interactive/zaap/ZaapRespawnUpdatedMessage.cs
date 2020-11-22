using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ZaapRespawnUpdatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6571;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;

        public ZaapRespawnUpdatedMessage()
        {
        }

        public ZaapRespawnUpdatedMessage(
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