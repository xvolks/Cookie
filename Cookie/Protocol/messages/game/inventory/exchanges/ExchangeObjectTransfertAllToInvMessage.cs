using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectTransfertAllToInvMessage : NetworkMessage
    {
        public const uint ProtocolId = 6032;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeObjectTransfertAllToInvMessage()
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