namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceInvitationStateRecruterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6396;
        public override ushort MessageID => ProtocolId;
        public string RecrutedName { get; set; }
        public byte InvitationState { get; set; }

        public AllianceInvitationStateRecruterMessage(string recrutedName, byte invitationState)
        {
            RecrutedName = recrutedName;
            InvitationState = invitationState;
        }

        public AllianceInvitationStateRecruterMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(RecrutedName);
            writer.WriteByte(InvitationState);
        }

        public override void Deserialize(IDataReader reader)
        {
            RecrutedName = reader.ReadUTF();
            InvitationState = reader.ReadByte();
        }

    }
}
