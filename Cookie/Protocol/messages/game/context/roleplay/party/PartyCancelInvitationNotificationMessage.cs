using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 6251;
        public override uint MessageID { get { return ProtocolId; } }

        public long CancelerId = 0;
        public long GuestId = 0;

        public PartyCancelInvitationNotificationMessage(): base()
        {
        }

        public PartyCancelInvitationNotificationMessage(
            int partyId,
            long cancelerId,
            long guestId
        ): base(
            partyId
        )
        {
            CancelerId = cancelerId;
            GuestId = guestId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(CancelerId);
            writer.WriteVarLong(GuestId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarLong();
            GuestId = reader.ReadVarLong();
        }
    }
}