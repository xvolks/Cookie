using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Approach
{
    public class ServerSessionConstantLong : ServerSessionConstant
    {
        public new const ushort ProtocolId = 429;

        public ServerSessionConstantLong(double value)
        {
            Value = value;
        }

        public ServerSessionConstantLong()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadDouble();
        }
    }
}