using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidSearchOkMessage : NetworkMessage
    {
        public const uint ProtocolId = 5802;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeBidSearchOkMessage()
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