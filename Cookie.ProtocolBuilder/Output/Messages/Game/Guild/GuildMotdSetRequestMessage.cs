namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Messages.Game.Social;
    using Utils.IO;

    public class GuildMotdSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const ushort ProtocolId = 6588;
        public override ushort MessageID => ProtocolId;
        public string Content { get; set; }

        public GuildMotdSetRequestMessage(string content)
        {
            Content = content;
        }

        public GuildMotdSetRequestMessage() { }

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
