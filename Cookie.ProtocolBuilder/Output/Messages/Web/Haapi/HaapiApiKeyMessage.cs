namespace Cookie.API.Protocol.Network.Messages.Web.Haapi
{
    using Utils.IO;

    public class HaapiApiKeyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6649;
        public override ushort MessageID => ProtocolId;
        public byte ReturnType { get; set; }
        public byte KeyType { get; set; }
        public string Token { get; set; }

        public HaapiApiKeyMessage(byte returnType, byte keyType, string token)
        {
            ReturnType = returnType;
            KeyType = keyType;
            Token = token;
        }

        public HaapiApiKeyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ReturnType);
            writer.WriteByte(KeyType);
            writer.WriteUTF(Token);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReturnType = reader.ReadByte();
            KeyType = reader.ReadByte();
            Token = reader.ReadUTF();
        }

    }
}
