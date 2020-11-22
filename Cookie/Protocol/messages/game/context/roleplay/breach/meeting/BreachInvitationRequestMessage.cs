using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachInvitationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6794;
        public override uint MessageID { get { return ProtocolId; } }

        public long Guest = 0;

        public BreachInvitationRequestMessage()
        {
        }

        public BreachInvitationRequestMessage(
            long guest
        )
        {
            Guest = guest;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Guest);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Guest = reader.ReadVarLong();
        }
    }
}