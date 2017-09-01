namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Context.Roleplay;
    using Types.Game.Guild;
    using Utils.IO;

    public class AlliancedGuildFactSheetInformations : GuildInformations
    {
        public new const ushort ProtocolId = 422;
        public override ushort TypeID => ProtocolId;
        public BasicNamedAllianceInformations AllianceInfos { get; set; }

        public AlliancedGuildFactSheetInformations(BasicNamedAllianceInformations allianceInfos)
        {
            AllianceInfos = allianceInfos;
        }

        public AlliancedGuildFactSheetInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicNamedAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }

    }
}
