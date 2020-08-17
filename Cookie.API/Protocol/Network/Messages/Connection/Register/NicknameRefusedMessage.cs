namespace Cookie.API.Protocol.Network.Messages.Connection.Register
{
    using Utils.IO;

    public class NicknameRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5638;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public NicknameRefusedMessage(byte reason)
        {
            Reason = reason;
        }

        public NicknameRefusedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
