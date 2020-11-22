using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyLeaveMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5594;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyLeaveMessage(): base()
        {
        }

        public PartyLeaveMessage(
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