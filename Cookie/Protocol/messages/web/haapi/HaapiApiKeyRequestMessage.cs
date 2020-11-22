using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HaapiApiKeyRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6648;
        public override uint MessageID { get { return ProtocolId; } }

        public HaapiApiKeyRequestMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}