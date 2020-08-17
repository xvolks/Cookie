namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class GuildMembershipMessage : GuildJoinedMessage
    {
        public new const ushort ProtocolId = 5835;
        public override ushort MessageID => ProtocolId;

        public GuildMembershipMessage() { }

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
