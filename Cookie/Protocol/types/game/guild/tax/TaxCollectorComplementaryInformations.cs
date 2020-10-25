using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorComplementaryInformations : NetworkType
    {
        public const short ProtocolId = 448;
        public override short TypeId { get { return ProtocolId; } }

        public TaxCollectorComplementaryInformations()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}