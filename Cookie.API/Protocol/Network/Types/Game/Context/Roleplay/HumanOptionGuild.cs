using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class HumanOptionGuild : HumanOption
    {
        public new const ushort ProtocolId = 409;

        public HumanOptionGuild(GuildInformations guildInformations)
        {
            GuildInformations = guildInformations;
        }

        public HumanOptionGuild()
        {
        }

        public override ushort TypeID => ProtocolId;
        public GuildInformations GuildInformations { get; set; }

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