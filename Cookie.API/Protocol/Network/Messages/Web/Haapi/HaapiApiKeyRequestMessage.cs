using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Haapi
{
    public class HaapiApiKeyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6648;

        public HaapiApiKeyRequestMessage(byte keyType)
        {
            KeyType = keyType;
        }

        public HaapiApiKeyRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte KeyType { get; set; }

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