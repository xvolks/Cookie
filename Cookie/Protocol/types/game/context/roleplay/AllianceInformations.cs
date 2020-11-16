using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AllianceInformations : BasicNamedAllianceInformations
    {
        public new const short ProtocolId = 417;
        public override short TypeId { get { return ProtocolId; } }

        public GuildEmblem AllianceEmblem;

        public AllianceInformations(): base()
        {
        }

        public AllianceInformations(
            int allianceId,
            string allianceTag,
            string allianceName,
            GuildEmblem allianceEmblem
        ): base(
            allianceId,
            allianceTag,
            allianceName
        )
        {
            AllianceEmblem = allianceEmblem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }
    }
}