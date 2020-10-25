using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInAllianceFactsMessage : GuildFactsMessage
    {
        public new const uint ProtocolId = 6422;
        public override uint MessageID { get { return ProtocolId; } }

        public BasicNamedAllianceInformations AllianceInfos;

        public GuildInAllianceFactsMessage(): base()
        {
        }

        public GuildInAllianceFactsMessage(
            GuildFactSheetInformations infos,
            int creationDate,
            short nbTaxCollectors,
            List<CharacterMinimalGuildPublicInformations> members,
            BasicNamedAllianceInformations allianceInfos
        ): base(
            infos,
            creationDate,
            nbTaxCollectors,
            members
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