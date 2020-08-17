namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Guild;
    using Utils.IO;

    public class GuildInformationsMemberUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5597;
        public override ushort MessageID => ProtocolId;
        public GuildMember Member { get; set; }

        public GuildInformationsMemberUpdateMessage(GuildMember member)
        {
            Member = member;
        }

        public GuildInformationsMemberUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Member.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Member = new GuildMember();
            Member.Deserialize(reader);
        }

    }
}
