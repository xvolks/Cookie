using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
    {
        public new const ushort ProtocolId = 440;

        public override ushort TypeID => ProtocolId;

        public AllianceInformations AllianceIdentity { get; set; }
        public TaxCollectorStaticExtendedInformations() { }

        public TaxCollectorStaticExtendedInformations( AllianceInformations AllianceIdentity ){
            this.AllianceIdentity = AllianceIdentity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceIdentity.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceIdentity = new AllianceInformations();
            AllianceIdentity.Deserialize(reader);
        }
    }
}
