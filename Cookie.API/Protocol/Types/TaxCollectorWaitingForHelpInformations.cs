using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 447;

        public override ushort TypeID => ProtocolId;

        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }
        public TaxCollectorWaitingForHelpInformations() { }

        public TaxCollectorWaitingForHelpInformations( ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo ){
            this.WaitingForHelpInfo = WaitingForHelpInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            WaitingForHelpInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            WaitingForHelpInfo.Deserialize(reader);
        }
    }
}
