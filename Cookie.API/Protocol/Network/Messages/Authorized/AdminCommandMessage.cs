namespace Cookie.API.Protocol.Network.Messages.Authorized
{
    using Utils.IO;

    public class AdminCommandMessage : NetworkMessage
    {
        public const ushort ProtocolId = 76;
        public override ushort MessageID => ProtocolId;
        public string Content { get; set; }

        public AdminCommandMessage(string content)
        {
            Content = content;
        }

        public AdminCommandMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Content = reader.ReadUTF();
        }

    }
}
