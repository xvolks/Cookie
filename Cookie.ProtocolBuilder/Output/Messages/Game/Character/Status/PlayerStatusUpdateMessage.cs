namespace Cookie.API.Protocol.Network.Messages.Game.Character.Status
{
    using Types.Game.Character.Status;
    using Utils.IO;

    public class PlayerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6386;
        public override ushort MessageID => ProtocolId;
        public int AccountId { get; set; }
        public ulong PlayerId { get; set; }
        public PlayerStatus Status { get; set; }

        public PlayerStatusUpdateMessage(int accountId, ulong playerId, PlayerStatus status)
        {
            AccountId = accountId;
            PlayerId = playerId;
            Status = status;
        }

        public PlayerStatusUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUShort(Status.TypeID);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadVarUhLong();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
        }

    }
}
