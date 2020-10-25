using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountSterilizeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5962;
        public override uint MessageID { get { return ProtocolId; } }

        public MountSterilizeRequestMessage()
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