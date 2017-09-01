namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    using Utils.IO;

    public class StatisticDataShort : StatisticData
    {
        public new const ushort ProtocolId = 488;
        public override ushort TypeID => ProtocolId;
        public short Value { get; set; }

        public StatisticDataShort(short value)
        {
            Value = value;
        }

        public StatisticDataShort() { }

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
