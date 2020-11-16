using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
    {
        public new const short ProtocolId = 426;
        public override short TypeId { get { return ProtocolId; } }

        public BasicAllianceInformations AllianceInfos;

        public FightTeamMemberWithAllianceCharacterInformations(): base()
        {
        }

        public FightTeamMemberWithAllianceCharacterInformations(
            double id_,
            string name,
            short level,
            BasicAllianceInformations allianceInfos
        ): base(
            id_,
            name,
            level
        )
        {
            AllianceInfos = allianceInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}