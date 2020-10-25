using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeRequestOnTaxCollectorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5779;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeRequestOnTaxCollectorMessage()
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