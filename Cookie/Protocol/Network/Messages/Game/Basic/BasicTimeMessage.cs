using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Basic
{
    public class BasicTimeMessage : NetworkMessage
    {
        public const uint ProtocolId = 175;
        public override uint MessageID => ProtocolId;

        public double Timestamp;
        public short TimezoneOffset;

        public BasicTimeMessage() { }

        public BasicTimeMessage(double timestamp, short timezoneOffset)
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
