using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceInvitationStateRecrutedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6392;
        public override uint MessageID { get { return ProtocolId; } }

        public byte InvitationState = 0;

        public AllianceInvitationStateRecrutedMessage()
        {
        }

        public AllianceInvitationStateRecrutedMessage(
            byte invitationState
        )
        {
            InvitationState = invitationState;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(InvitationState);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            InvitationState = reader.ReadByte();
        }
    }
}