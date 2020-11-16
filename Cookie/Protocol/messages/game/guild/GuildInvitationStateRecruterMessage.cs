using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInvitationStateRecruterMessage : NetworkMessage
    {
        public const uint ProtocolId = 5563;
        public override uint MessageID { get { return ProtocolId; } }

        public string RecrutedName;
        public byte InvitationState = 0;

        public GuildInvitationStateRecruterMessage()
        {
        }

        public GuildInvitationStateRecruterMessage(
            string recrutedName,
            byte invitationState
        )
        {
            RecrutedName = recrutedName;
            InvitationState = invitationState;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(RecrutedName);
            writer.WriteByte(InvitationState);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RecrutedName = reader.ReadUTF();
            InvitationState = reader.ReadByte();
        }
    }
}