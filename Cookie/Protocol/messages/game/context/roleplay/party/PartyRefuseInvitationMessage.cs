using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyRefuseInvitationMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5582;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyRefuseInvitationMessage(): base()
        {
        }

        public PartyRefuseInvitationMessage(
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