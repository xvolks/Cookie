using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicLatencyStatsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5663;
        public override uint MessageID { get { return ProtocolId; } }

        public short Latency = 0;
        public short SampleCount = 0;
        public short Max = 0;

        public BasicLatencyStatsMessage()
        {
        }

        public BasicLatencyStatsMessage(
            short latency,
            short sampleCount,
            short max
        )
        {
            Latency = latency;
            SampleCount = sampleCount;
            Max = max;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Latency);
            writer.WriteVarShort(SampleCount);
            writer.WriteVarShort(Max);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Latency = reader.ReadShort();
            SampleCount = reader.ReadVarShort();
            Max = reader.ReadVarShort();
        }
    }
}