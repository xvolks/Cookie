namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Messages.Game.Social;
    using Utils.IO;

    public class AllianceBulletinSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const ushort ProtocolId = 6693;
        public override ushort MessageID => ProtocolId;
        public string Content { get; set; }
        public bool NotifyMembers { get; set; }

        public AllianceBulletinSetRequestMessage(string content, bool notifyMembers)
        {
            Content = content;
            NotifyMembers = notifyMembers;
        }

        public AllianceBulletinSetRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
            writer.WriteBoolean(NotifyMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
            NotifyMembers = reader.ReadBoolean();
        }

    }
}
