using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ErrorMapNotFoundMessage : NetworkMessage
    {
        public const uint ProtocolId = 6197;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;

        public ErrorMapNotFoundMessage()
        {
        }

        public ErrorMapNotFoundMessage(
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