using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
    {
        public new const ushort ProtocolId = 426;

        public FightTeamMemberWithAllianceCharacterInformations(BasicAllianceInformations allianceInfos)
        {
            AllianceInfos = allianceInfos;
        }

        public FightTeamMemberWithAllianceCharacterInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public BasicAllianceInformations AllianceInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}