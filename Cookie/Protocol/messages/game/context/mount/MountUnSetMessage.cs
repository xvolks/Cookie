using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountUnSetMessage : NetworkMessage
    {
        public const uint ProtocolId = 5982;
        public override uint MessageID { get { return ProtocolId; } }

        public MountUnSetMessage()
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