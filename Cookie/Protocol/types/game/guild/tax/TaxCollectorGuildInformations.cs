using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
    {
        public new const short ProtocolId = 446;
        public override short TypeId { get { return ProtocolId; } }

        public BasicGuildInformations Guild;

        public TaxCollectorGuildInformations(): base()
        {
        }

        public TaxCollectorGuildInformations(
            BasicGuildInformations guild
        ): base()
        {
            Guild = guild;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}