namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    using Utils.IO;

    public class StatisticDataString : StatisticData
    {
        public new const ushort ProtocolId = 487;
        public override ushort TypeID => ProtocolId;
        public string Value { get; set; }

        public StatisticDataString(string value)
        {
            Value = value;
        }

        public StatisticDataString() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadUTF();
        }

    }
}
