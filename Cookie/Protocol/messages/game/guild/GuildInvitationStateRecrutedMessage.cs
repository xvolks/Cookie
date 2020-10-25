using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInvitationStateRecrutedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5548;
        public override uint MessageID { get { return ProtocolId; } }

        public byte InvitationState = 0;

        public GuildInvitationStateRecrutedMessage()
        {
        }

        public GuildInvitationStateRecrutedMessage(
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