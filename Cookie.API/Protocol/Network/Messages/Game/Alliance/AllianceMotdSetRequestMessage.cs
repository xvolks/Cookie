namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Messages.Game.Social;
    using Utils.IO;

    public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const ushort ProtocolId = 6687;
        public override ushort MessageID => ProtocolId;
        public string Content { get; set; }

        public AllianceMotdSetRequestMessage(string content)
        {
            Content = content;
        }

        public AllianceMotdSetRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
        }

    }
}
