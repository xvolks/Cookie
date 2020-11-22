using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatisticDataInt : StatisticData
    {
        public new const short ProtocolId = 485;
        public override short TypeId { get { return ProtocolId; } }

        public int Value = 0;

        public StatisticDataInt(): base()
        {
        }

        public StatisticDataInt(
            int value
        ): base()
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}