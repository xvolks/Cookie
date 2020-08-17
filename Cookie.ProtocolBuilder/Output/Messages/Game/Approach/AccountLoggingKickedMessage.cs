namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    using Utils.IO;

    public class AccountLoggingKickedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6029;
        public override ushort MessageID => ProtocolId;
        public ushort Days { get; set; }
        public byte Hours { get; set; }
        public byte Minutes { get; set; }

        public AccountLoggingKickedMessage(ushort days, byte hours, byte minutes)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public AccountLoggingKickedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Days);
            writer.WriteByte(Hours);
            writer.WriteByte(Minutes);
        }

        public override void Deserialize(IDataReader reader)
        {
            Days = reader.ReadVarUhShort();
            Hours = reader.ReadByte();
            Minutes = reader.ReadByte();
        }

    }
}
