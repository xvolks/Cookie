using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5961;
        public override uint MessageID { get { return ProtocolId; } }

        public byte SourceType = 0;
        public byte DestinationType = 0;
        public double MapId = 0;

        public TeleportRequestMessage()
        {
        }

        public TeleportRequestMessage(
            byte sourceType,
            byte destinationType,
            double mapId
        )
        {
            SourceType = sourceType;
            DestinationType = destinationType;
            MapId = mapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(SourceType);
            writer.WriteByte(DestinationType);
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SourceType = reader.ReadByte();
            DestinationType = reader.ReadByte();
            MapId = reader.ReadDouble();
        }
    }
}