using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyDeletedMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6261;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyDeletedMessage(): base()
        {
        }

        public PartyDeletedMessage(
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