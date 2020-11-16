using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartAsVendorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5775;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeStartAsVendorMessage()
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