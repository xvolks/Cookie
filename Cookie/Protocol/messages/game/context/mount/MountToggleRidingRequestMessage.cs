using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountToggleRidingRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5976;
        public override uint MessageID { get { return ProtocolId; } }

        public MountToggleRidingRequestMessage()
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