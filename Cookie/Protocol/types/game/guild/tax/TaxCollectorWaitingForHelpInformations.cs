using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
    {
        public new const short ProtocolId = 447;
        public override short TypeId { get { return ProtocolId; } }

        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo;

        public TaxCollectorWaitingForHelpInformations(): base()
        {
        }

        public TaxCollectorWaitingForHelpInformations(
            ProtectedEntityWaitingForHelpInfo waitingForHelpInfo
        ): base()
        {
            WaitingForHelpInfo = waitingForHelpInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            WaitingForHelpInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            WaitingForHelpInfo.Deserialize(reader);
        }
    }
}