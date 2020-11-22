using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorComplementaryInformations : NetworkType
    {
        public const ushort ProtocolId = 448;

        public override ushort TypeID => ProtocolId;

        public TaxCollectorComplementaryInformations() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}
