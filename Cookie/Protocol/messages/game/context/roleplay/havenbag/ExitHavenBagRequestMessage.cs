using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExitHavenBagRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6631;
        public override uint MessageID { get { return ProtocolId; } }

        public ExitHavenBagRequestMessage()
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