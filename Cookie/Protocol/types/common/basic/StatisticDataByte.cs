using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatisticDataByte : StatisticData
    {
        public new const short ProtocolId = 486;
        public override short TypeId { get { return ProtocolId; } }

        public byte Value = 0;

        public StatisticDataByte(): base()
        {
        }

        public StatisticDataByte(
            byte value
        ): base()
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadByte();
        }
    }
}