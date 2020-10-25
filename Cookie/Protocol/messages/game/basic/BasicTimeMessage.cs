using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicTimeMessage : NetworkMessage
    {
        public const uint ProtocolId = 175;
        public override uint MessageID { get { return ProtocolId; } }

        public double Timestamp = 0;
        public short TimezoneOffset = 0;

        public BasicTimeMessage()
        {
        }

        public BasicTimeMessage(
            double timestamp,
            short timezoneOffset
        )
        {
            Timestamp = timestamp;
            TimezoneOffset = timezoneOffset;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Timestamp);
            writer.WriteShort(TimezoneOffset);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Timestamp = reader.ReadDouble();
            TimezoneOffset = reader.ReadShort();
        }
    }
}