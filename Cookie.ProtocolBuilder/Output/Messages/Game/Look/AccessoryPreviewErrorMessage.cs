namespace Cookie.API.Protocol.Network.Messages.Game.Look
{
    using Utils.IO;

    public class AccessoryPreviewErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6521;
        public override ushort MessageID => ProtocolId;
        public byte Error { get; set; }

        public AccessoryPreviewErrorMessage(byte error)
        {
            Error = error;
        }

        public AccessoryPreviewErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadByte();
        }

    }
}
