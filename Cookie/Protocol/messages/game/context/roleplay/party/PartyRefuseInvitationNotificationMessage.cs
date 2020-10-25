using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyRefuseInvitationNotificationMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 5596;
        public override uint MessageID { get { return ProtocolId; } }

        public long GuestId = 0;

        public PartyRefuseInvitationNotificationMessage(): base()
        {
        }

        public PartyRefuseInvitationNotificationMessage(
            int partyId,
            long guestId
        ): base(
            partyId
        )
        {
            GuestId = guestId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(GuestId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            GuestId = reader.ReadVarLong();
        }
    }
}