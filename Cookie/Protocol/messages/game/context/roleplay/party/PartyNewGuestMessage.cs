using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyNewGuestMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 6260;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyGuestInformations Guest;

        public PartyNewGuestMessage(): base()
        {
        }

        public PartyNewGuestMessage(
            int partyId,
            PartyGuestInformations guest
        ): base(
            partyId
        )
        {
            Guest = guest;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Guest.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Guest = new PartyGuestInformations();
            Guest.Deserialize(reader);
        }
    }
}