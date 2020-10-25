using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyCancelInvitationMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6254;
        public override uint MessageID { get { return ProtocolId; } }

        public long GuestId = 0;

        public PartyCancelInvitationMessage(): base()
        {
        }

        public PartyCancelInvitationMessage(
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