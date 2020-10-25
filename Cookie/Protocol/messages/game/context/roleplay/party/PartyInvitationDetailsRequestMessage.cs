using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationDetailsRequestMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6264;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyInvitationDetailsRequestMessage(): base()
        {
        }

        public PartyInvitationDetailsRequestMessage(
            int partyId
        ): base(
            partyId
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