namespace Cookie.API.Protocol.Network.Types.Game.Approach
{
    using Utils.IO;

    public class ServerSessionConstantInteger : ServerSessionConstant
    {
        public new const ushort ProtocolId = 433;
        public override ushort TypeID => ProtocolId;
        public int Value { get; set; }

        public ServerSessionConstantInteger(int value)
        {
            Value = value;
        }

        public ServerSessionConstantInteger() { }

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
