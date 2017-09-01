using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.House
{
    public class HouseGuildedInformations : HouseInstanceInformations
    {
        public new const ushort ProtocolId = 512;

        public HouseGuildedInformations(GuildInformations guildInfo)
        {
            GuildInfo = guildInfo;
        }

        public HouseGuildedInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public GuildInformations GuildInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}