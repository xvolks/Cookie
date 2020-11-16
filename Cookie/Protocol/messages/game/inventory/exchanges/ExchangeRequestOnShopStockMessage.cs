using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeRequestOnShopStockMessage : NetworkMessage
    {
        public const uint ProtocolId = 5753;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeRequestOnShopStockMessage()
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