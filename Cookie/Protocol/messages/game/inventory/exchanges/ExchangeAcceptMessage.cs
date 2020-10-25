using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeAcceptMessage : NetworkMessage
    {
        public const uint ProtocolId = 5508;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeAcceptMessage()
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