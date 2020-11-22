using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyLeaveRequestMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5593;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyLeaveRequestMessage(): base()
        {
        }

        public PartyLeaveRequestMessage(
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