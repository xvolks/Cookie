using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    public class StatisticDataByte : StatisticData
    {
        public new const ushort ProtocolId = 486;

        public StatisticDataByte(sbyte value)
        {
            Value = value;
        }

        public StatisticDataByte()
        {
        }

        public override ushort TypeID => ProtocolId;
        public sbyte Value { get; set; }

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