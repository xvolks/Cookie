using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
    {
        public new const uint ProtocolId = 6283;
        public override uint MessageID { get { return ProtocolId; } }

        public PartyInvitationArenaRequestMessage(): base()
        {
        }

        public PartyInvitationArenaRequestMessage(
            string name
        ): base(
            name
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