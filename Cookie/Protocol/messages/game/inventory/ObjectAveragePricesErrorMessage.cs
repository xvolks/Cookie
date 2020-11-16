using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectAveragePricesErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6336;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectAveragePricesErrorMessage()
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