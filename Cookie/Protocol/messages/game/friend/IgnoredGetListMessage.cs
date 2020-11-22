using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IgnoredGetListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5676;
        public override uint MessageID { get { return ProtocolId; } }

        public IgnoredGetListMessage()
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