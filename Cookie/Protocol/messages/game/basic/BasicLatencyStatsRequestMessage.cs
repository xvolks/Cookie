using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicLatencyStatsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5816;
        public override uint MessageID { get { return ProtocolId; } }

        public BasicLatencyStatsRequestMessage()
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