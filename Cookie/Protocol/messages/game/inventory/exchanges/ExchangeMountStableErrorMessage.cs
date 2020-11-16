using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountStableErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5981;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeMountStableErrorMessage()
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