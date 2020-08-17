namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Guild;
    using Utils.IO;

    public class GuildInformations : BasicGuildInformations
    {
        public new const ushort ProtocolId = 127;
        public override ushort TypeID => ProtocolId;
        public GuildEmblem GuildEmblem { get; set; }

        public GuildInformations(GuildEmblem guildEmblem)
        {
            GuildEmblem = guildEmblem;
        }

        public GuildInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildEmblem = new GuildEmblem();
            GuildEmblem.Deserialize(reader);
        }

    }
}
