using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class AlliancedGuildFactSheetInformations : GuildInformations
    {
        public new const ushort ProtocolId = 422;

        public AlliancedGuildFactSheetInformations(BasicNamedAllianceInformations allianceInfos)
        {
            AllianceInfos = allianceInfos;
        }

        public AlliancedGuildFactSheetInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public BasicNamedAllianceInformations AllianceInfos { get; set; }

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