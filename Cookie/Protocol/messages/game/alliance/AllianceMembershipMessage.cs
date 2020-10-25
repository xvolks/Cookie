using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceMembershipMessage : AllianceJoinedMessage
    {
        public new const uint ProtocolId = 6390;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceMembershipMessage(): base()
        {
        }

        public AllianceMembershipMessage(
            AllianceInformations allianceInfo,
            bool enabled,
            int leadingGuildId
        ): base(
            allianceInfo,
            enabled,
            leadingGuildId
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}