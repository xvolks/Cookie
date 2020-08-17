namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildInvitationStateRecrutedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5548;
        public override ushort MessageID => ProtocolId;
        public byte InvitationState { get; set; }

        public GuildInvitationStateRecrutedMessage(byte invitationState)
        {
            InvitationState = invitationState;
        }

        public GuildInvitationStateRecrutedMessage() { }

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
