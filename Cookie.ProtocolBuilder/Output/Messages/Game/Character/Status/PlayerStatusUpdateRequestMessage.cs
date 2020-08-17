namespace Cookie.API.Protocol.Network.Messages.Game.Character.Status
{
    using Types.Game.Character.Status;
    using Utils.IO;

    public class PlayerStatusUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6387;
        public override ushort MessageID => ProtocolId;
        public PlayerStatus Status { get; set; }

        public PlayerStatusUpdateRequestMessage(PlayerStatus status)
        {
            Status = status;
        }

        public PlayerStatusUpdateRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Status.TypeID);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
        }

    }
}
