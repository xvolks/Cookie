namespace Cookie.API.Protocol.Network.Messages.Web.Haapi
{
    using Utils.IO;

    public class HaapiApiKeyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6648;
        public override ushort MessageID => ProtocolId;
        

        

        public HaapiApiKeyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
           
        }

        public override void Deserialize(IDataReader reader)
        {
            
        }

    }
}
