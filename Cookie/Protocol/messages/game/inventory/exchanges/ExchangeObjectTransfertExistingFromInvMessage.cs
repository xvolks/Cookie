using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectTransfertExistingFromInvMessage : NetworkMessage
    {
        public const uint ProtocolId = 6325;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeObjectTransfertExistingFromInvMessage()
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