using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    public class StatisticDataString : StatisticData
    {
        public new const ushort ProtocolId = 487;

        public StatisticDataString(string value)
        {
            Value = value;
        }

        public StatisticDataString()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string Value { get; set; }

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