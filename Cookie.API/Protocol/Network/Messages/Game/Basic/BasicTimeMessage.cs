namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicTimeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 175;
        public override ushort MessageID => ProtocolId;
        public double Timestamp { get; set; }
        public short TimezoneOffset { get; set; }

        public BasicTimeMessage(double timestamp, short timezoneOffset)
        {
            Timestamp = timestamp;
            TimezoneOffset = timezoneOffset;
        }

        public BasicTimeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Timestamp);
            writer.WriteShort(TimezoneOffset);
        }

        public override void Deserialize(IDataReader reader)
        {
            Timestamp = reader.ReadDouble();
            TimezoneOffset = reader.ReadShort();
        }

    }
}
