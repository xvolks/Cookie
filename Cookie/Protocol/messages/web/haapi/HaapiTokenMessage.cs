using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HaapiTokenMessage : NetworkMessage
    {
        public const uint ProtocolId = 6767;
        public override uint MessageID { get { return ProtocolId; } }

        public string Token;

        public HaapiTokenMessage()
        {
        }

        public HaapiTokenMessage(
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