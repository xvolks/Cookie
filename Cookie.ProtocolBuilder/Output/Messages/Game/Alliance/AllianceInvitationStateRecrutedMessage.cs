namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceInvitationStateRecrutedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6392;
        public override ushort MessageID => ProtocolId;
        public byte InvitationState { get; set; }

        public AllianceInvitationStateRecrutedMessage(byte invitationState)
        {
            InvitationState = invitationState;
        }

        public AllianceInvitationStateRecrutedMessage() { }

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
