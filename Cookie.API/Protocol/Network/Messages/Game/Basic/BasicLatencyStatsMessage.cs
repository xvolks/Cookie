namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicLatencyStatsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5663;
        public override ushort MessageID => ProtocolId;
        public ushort Latency { get; set; }
        public ushort SampleCount { get; set; }
        public ushort Max { get; set; }

        public BasicLatencyStatsMessage(ushort latency, ushort sampleCount, ushort max)
        {
            Latency = latency;
            SampleCount = sampleCount;
            Max = max;
        }

        public BasicLatencyStatsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Latency);
            writer.WriteVarUhShort(SampleCount);
            writer.WriteVarUhShort(Max);
        }

        public override void Deserialize(IDataReader reader)
        {
            Latency = reader.ReadUShort();
            SampleCount = reader.ReadVarUhShort();
            Max = reader.ReadVarUhShort();
        }

    }
}
