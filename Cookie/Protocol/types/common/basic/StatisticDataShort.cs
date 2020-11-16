using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatisticDataShort : StatisticData
    {
        public new const short ProtocolId = 488;
        public override short TypeId { get { return ProtocolId; } }

        public short Value = 0;

        public StatisticDataShort(): base()
        {
        }

        public StatisticDataShort(
            short value
        ): base()
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadShort();
        }
    }
}