using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountHarnessDissociateRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6696;
        public override uint MessageID { get { return ProtocolId; } }

        public MountHarnessDissociateRequestMessage()
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