using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AlliancePrismInformation : PrismInformation
    {
        public new const short ProtocolId = 427;
        public override short TypeId { get { return ProtocolId; } }

        public AllianceInformations Alliance;

        public AlliancePrismInformation(): base()
        {
        }

        public AlliancePrismInformation(
            byte typeId_,
            byte state,
            int nextVulnerabilityDate,
            int placementDate,
            int rewardTokenCount,
            AllianceInformations alliance
        ): base(
            typeId_,
            state,
            nextVulnerabilityDate,
            placementDate,
            rewardTokenCount
        )
        {
            Alliance = alliance;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Alliance = new AllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}