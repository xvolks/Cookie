namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    using Utils.IO;

    public class ChatErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 870;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public ChatErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public ChatErrorMessage() { }

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
