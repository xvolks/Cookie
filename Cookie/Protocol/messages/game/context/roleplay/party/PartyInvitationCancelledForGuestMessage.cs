using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6256;
        public override uint MessageID { get { return ProtocolId; } }

        public long CancelerId = 0;

        public PartyInvitationCancelledForGuestMessage(): base()
        {
        }

        public PartyInvitationCancelledForGuestMessage(
            int partyId,
            long cancelerId
        ): base(
            partyId
        )
        {
            CancelerId = cancelerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(CancelerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarLong();
        }
    }
}