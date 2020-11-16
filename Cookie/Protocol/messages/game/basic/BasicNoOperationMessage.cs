using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicNoOperationMessage : NetworkMessage
    {
        public const uint ProtocolId = 176;
        public override uint MessageID { get { return ProtocolId; } }

        public BasicNoOperationMessage()
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