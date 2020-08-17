namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    using Utils.IO;

    public class StatisticDataByte : StatisticData
    {
        public new const ushort ProtocolId = 486;
        public override ushort TypeID => ProtocolId;
        public sbyte Value { get; set; }

        public StatisticDataByte(sbyte value)
        {
            Value = value;
        }

        public StatisticDataByte() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadSByte();
        }

    }
}
