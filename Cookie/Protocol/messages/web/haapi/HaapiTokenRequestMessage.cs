using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HaapiTokenRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6766;
        public override uint MessageID { get { return ProtocolId; } }

        public HaapiTokenRequestMessage()
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