using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 446;

        public TaxCollectorGuildInformations(BasicGuildInformations guild)
        {
            Guild = guild;
        }

        public TaxCollectorGuildInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public BasicGuildInformations Guild { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}