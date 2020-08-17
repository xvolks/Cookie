namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildInvitationStateRecruterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5563;
        public override ushort MessageID => ProtocolId;
        public string RecrutedName { get; set; }
        public byte InvitationState { get; set; }

        public GuildInvitationStateRecruterMessage(string recrutedName, byte invitationState)
        {
            RecrutedName = recrutedName;
            InvitationState = invitationState;
        }

        public GuildInvitationStateRecruterMessage() { }

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
