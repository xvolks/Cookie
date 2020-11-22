using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AlliancePrismInformation : PrismInformation
    {
        public new const ushort ProtocolId = 427;

        public override ushort TypeID => ProtocolId;

        public AllianceInformations Alliance { get; set; }
        public AlliancePrismInformation() { }

        public AlliancePrismInformation( AllianceInformations Alliance ){
            this.Alliance = Alliance;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new AllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}
