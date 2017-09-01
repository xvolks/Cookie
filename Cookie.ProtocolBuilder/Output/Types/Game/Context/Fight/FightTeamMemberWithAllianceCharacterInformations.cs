namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
    {
        public new const ushort ProtocolId = 426;
        public override ushort TypeID => ProtocolId;
        public BasicAllianceInformations AllianceInfos { get; set; }

        public FightTeamMemberWithAllianceCharacterInformations(BasicAllianceInformations allianceInfos)
        {
            AllianceInfos = allianceInfos;
        }

        public FightTeamMemberWithAllianceCharacterInformations() { }

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
