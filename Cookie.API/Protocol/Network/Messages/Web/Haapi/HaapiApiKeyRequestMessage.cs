namespace Cookie.API.Protocol.Network.Messages.Web.Haapi
{
    using Utils.IO;

    public class HaapiApiKeyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6648;
        public override ushort MessageID => ProtocolId;
        public byte KeyType { get; set; }

        public HaapiApiKeyRequestMessage(byte keyType)
        {
            KeyType = keyType;
        }

        public HaapiApiKeyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(KeyType);
        }

        public override void Deserialize(IDataReader reader)
        {
            KeyType = reader.ReadByte();
        }

    }
}
