using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyRestrictedMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6175;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Restricted = false;

        public PartyRestrictedMessage(): base()
        {
        }

        public PartyRestrictedMessage(
            int partyId,
            bool restricted
        ): base(
            partyId
        )
        {
            Restricted = restricted;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Restricted);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Restricted = reader.ReadBoolean();
        }
    }
}