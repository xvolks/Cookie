namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class HumanOptionGuild : HumanOption
    {
        public new const ushort ProtocolId = 409;
        public override ushort TypeID => ProtocolId;
        public GuildInformations GuildInformations { get; set; }

        public HumanOptionGuild(GuildInformations guildInformations)
        {
            GuildInformations = guildInformations;
        }

        public HumanOptionGuild() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildInformations = new GuildInformations();
            GuildInformations.Deserialize(reader);
        }

    }
}
