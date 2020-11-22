using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HaapiApiKeyMessage : NetworkMessage
    {
        public const uint ProtocolId = 6649;
        public override uint MessageID { get { return ProtocolId; } }

        public string Token;

        public HaapiApiKeyMessage()
        {
        }

        public HaapiApiKeyMessage(
            string token
        )
        {
            Token = token;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Token);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Token = reader.ReadUTF();
        }
    }
}