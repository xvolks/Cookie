using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBuyOkMessage : NetworkMessage
    {
        public const uint ProtocolId = 5759;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeBuyOkMessage()
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