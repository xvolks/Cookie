using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicLatencyStatsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5663;

        public override ushort MessageID => ProtocolId;

        public ushort Latency { get; set; }
        public ushort SampleCount { get; set; }
        public ushort Max { get; set; }
        public BasicLatencyStatsMessage() { }

        public BasicLatencyStatsMessage( ushort Latency, ushort SampleCount, ushort Max ){
            this.Latency = Latency;
            this.SampleCount = SampleCount;
            this.Max = Max;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUnsignedShort(Latency);
            writer.WriteVarUhShort(SampleCount);
            writer.WriteVarUhShort(Max);
        }

        public override void Deserialize(IDataReader reader)
        {
            Latency = reader.ReadUnsignedShort();
            SampleCount = reader.ReadVarUhShort();
            Max = reader.ReadVarUhShort();
        }
    }
}
