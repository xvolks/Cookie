using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectAveragePricesGetMessage : NetworkMessage
    {
        public const uint ProtocolId = 6334;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectAveragePricesGetMessage()
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