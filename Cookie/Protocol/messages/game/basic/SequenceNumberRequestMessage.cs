using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SequenceNumberRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6316;
        public override uint MessageID { get { return ProtocolId; } }

        public SequenceNumberRequestMessage()
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