using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeSellOkMessage : NetworkMessage
    {
        public const uint ProtocolId = 5792;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeSellOkMessage()
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