using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectTransfertExistingToInvMessage : NetworkMessage
    {
        public const uint ProtocolId = 6326;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeObjectTransfertExistingToInvMessage()
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