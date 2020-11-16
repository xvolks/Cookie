using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 446;

        public override ushort TypeID => ProtocolId;

        public BasicGuildInformations Guild { get; set; }
        public TaxCollectorGuildInformations() { }

        public TaxCollectorGuildInformations( BasicGuildInformations Guild ){
            this.Guild = Guild;
        }

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
