using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AlliancedGuildFactSheetInformations : GuildInformations
    {
        public new const short ProtocolId = 422;
        public override short TypeId { get { return ProtocolId; } }

        public BasicNamedAllianceInformations AllianceInfos;

        public AlliancedGuildFactSheetInformations(): base()
        {
        }

        public AlliancedGuildFactSheetInformations(
            int guildId,
            string guildName,
            byte guildLevel,
            GuildEmblem guildEmblem_,
            BasicNamedAllianceInformations allianceInfos
        ): base(
            guildId,
            guildName,
            guildLevel,
            guildEmblem_
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
            AllianceInfos = new BasicNamedAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}