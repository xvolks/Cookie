using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyAcceptInvitationMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5580;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyAcceptInvitationMessage(): base()
        {
        }

        public PartyAcceptInvitationMessage(
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