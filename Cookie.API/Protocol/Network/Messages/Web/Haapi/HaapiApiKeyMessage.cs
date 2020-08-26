namespace Cookie.API.Protocol.Network.Messages.Web.Haapi
{
    using Utils.IO;

    public class HaapiApiKeyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6649;
        public override ushort MessageID => ProtocolId;
        
        public string Token { get; set; }

        public HaapiApiKeyMessage(string token)
        {
           
            Token = token;
        }

        public HaapiApiKeyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            
            writer.WriteUTF(Token);
        }

        public override void Deserialize(IDataReader reader)
        {
            
            Token = reader.ReadUTF();
        }

    }
}
