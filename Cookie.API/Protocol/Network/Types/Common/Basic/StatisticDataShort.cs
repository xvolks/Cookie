using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    public class StatisticDataShort : StatisticData
    {
        public new const ushort ProtocolId = 488;

        public StatisticDataShort(short value)
        {
            Value = value;
        }

        public StatisticDataShort()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadShort();
        }
    }
}