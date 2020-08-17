namespace Cookie.API.Protocol.Network.Messages.Authorized
{
    using Utils.IO;

    public class ConsoleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 75;
        public override ushort MessageID => ProtocolId;
        public byte Type { get; set; }
        public string Content { get; set; }

        public ConsoleMessage(byte type, string content)
        {
            Type = type;
            Content = content;
        }

        public ConsoleMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
            Content = reader.ReadUTF();
        }

    }
}
