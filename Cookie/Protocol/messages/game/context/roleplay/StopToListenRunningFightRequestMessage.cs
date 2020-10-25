using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StopToListenRunningFightRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6124;
        public override uint MessageID { get { return ProtocolId; } }

        public StopToListenRunningFightRequestMessage()
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