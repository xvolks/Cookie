using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInAllianceFactsMessage : GuildFactsMessage
    {
        public new const ushort ProtocolId = 6422;

        public GuildInAllianceFactsMessage(BasicNamedAllianceInformations allianceInfos)
        {
            AllianceInfos = allianceInfos;
        }

        public GuildInAllianceFactsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
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