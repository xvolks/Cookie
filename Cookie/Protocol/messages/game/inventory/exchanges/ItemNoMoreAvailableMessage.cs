using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ItemNoMoreAvailableMessage : NetworkMessage
    {
        public const uint ProtocolId = 5769;
        public override uint MessageID { get { return ProtocolId; } }

        public ItemNoMoreAvailableMessage()
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