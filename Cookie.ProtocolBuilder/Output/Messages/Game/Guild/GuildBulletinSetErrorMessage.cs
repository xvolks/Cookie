namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Messages.Game.Social;
    using Utils.IO;

    public class GuildBulletinSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const ushort ProtocolId = 6691;
        public override ushort MessageID => ProtocolId;

        public GuildBulletinSetErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
