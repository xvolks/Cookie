namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Utils.IO;

    public class IdentificationFailedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 20;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public IdentificationFailedMessage(byte reason)
        {
            Reason = reason;
        }

        public IdentificationFailedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
