using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    public class StatisticDataInt : StatisticData
    {
        public new const ushort ProtocolId = 485;

        public StatisticDataInt(int value)
        {
            Value = value;
        }

        public StatisticDataInt()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}