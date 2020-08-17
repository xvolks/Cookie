namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildInvitationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5551;
        public override ushort MessageID => ProtocolId;
        public ulong TargetId { get; set; }

        public GuildInvitationMessage(ulong targetId)
        {
            TargetId = targetId;
        }

        public GuildInvitationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadVarUhLong();
        }

    }
}
