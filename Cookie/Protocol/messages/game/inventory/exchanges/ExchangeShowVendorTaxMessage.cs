using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeShowVendorTaxMessage : NetworkMessage
    {
        public const uint ProtocolId = 5783;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeShowVendorTaxMessage()
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