using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceInvitationStateRecrutedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6392;

        public AllianceInvitationStateRecrutedMessage(byte invitationState)
        {
            InvitationState = invitationState;
        }

        public AllianceInvitationStateRecrutedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte InvitationState { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(InvitationState);
        }

        public override void Deserialize(IDataReader reader)
        {
            InvitationState = reader.ReadByte();
        }
    }
}