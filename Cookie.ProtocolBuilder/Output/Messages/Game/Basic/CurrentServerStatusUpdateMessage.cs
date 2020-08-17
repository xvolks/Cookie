namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class CurrentServerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6525;
        public override ushort MessageID => ProtocolId;
        public byte Status { get; set; }

        public CurrentServerStatusUpdateMessage(byte status)
        {
            Status = status;
        }

        public CurrentServerStatusUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Status);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = reader.ReadByte();
        }

    }
}
