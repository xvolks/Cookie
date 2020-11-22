using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class OpenHavenBagFurnitureSequenceRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6635;
        public override uint MessageID { get { return ProtocolId; } }

        public OpenHavenBagFurnitureSequenceRequestMessage()
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