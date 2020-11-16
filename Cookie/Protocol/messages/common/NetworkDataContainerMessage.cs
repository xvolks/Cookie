using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NetworkDataContainerMessage : NetworkMessage
    {
        public const uint ProtocolId = 2;
        public override uint MessageID { get { return ProtocolId; } }

        public NetworkDataContainerMessage()
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