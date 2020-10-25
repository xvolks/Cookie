using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismModuleExchangeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6531;
        public override uint MessageID { get { return ProtocolId; } }

        public PrismModuleExchangeRequestMessage()
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