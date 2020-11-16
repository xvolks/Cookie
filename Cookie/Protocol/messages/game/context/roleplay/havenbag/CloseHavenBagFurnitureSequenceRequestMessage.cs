using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CloseHavenBagFurnitureSequenceRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6621;
        public override uint MessageID { get { return ProtocolId; } }

        public CloseHavenBagFurnitureSequenceRequestMessage()
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