using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeRequestOnMountStockMessage : NetworkMessage
    {
        public const uint ProtocolId = 5986;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeRequestOnMountStockMessage()
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