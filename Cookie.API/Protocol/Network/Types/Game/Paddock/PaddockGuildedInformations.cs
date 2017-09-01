using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    public class PaddockGuildedInformations : PaddockBuyableInformations
    {
        public new const ushort ProtocolId = 508;

        public PaddockGuildedInformations(bool deserted, GuildInformations guildInfo)
        {
            Deserted = deserted;
            GuildInfo = guildInfo;
        }

        public PaddockGuildedInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool Deserted { get; set; }
        public GuildInformations GuildInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Deserted);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Deserted = reader.ReadBoolean();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}