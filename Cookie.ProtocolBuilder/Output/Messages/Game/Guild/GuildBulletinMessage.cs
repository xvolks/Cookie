namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Messages.Game.Social;
    using Utils.IO;

    public class GuildBulletinMessage : BulletinMessage
    {
        public new const ushort ProtocolId = 6689;
        public override ushort MessageID => ProtocolId;

        public GuildBulletinMessage() { }

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
