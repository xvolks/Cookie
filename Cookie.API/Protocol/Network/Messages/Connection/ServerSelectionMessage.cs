namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Utils.IO;

    public class ServerSelectionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 40;
        public override ushort MessageID => ProtocolId;
        public ushort ServerId { get; set; }

        public ServerSelectionMessage(ushort serverId)
        {
            ServerId = serverId;
        }

        public ServerSelectionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
        }

    }
}
