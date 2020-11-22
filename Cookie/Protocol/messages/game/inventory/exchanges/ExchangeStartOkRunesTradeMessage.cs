using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkRunesTradeMessage : NetworkMessage
    {
        public const uint ProtocolId = 6567;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeStartOkRunesTradeMessage()
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