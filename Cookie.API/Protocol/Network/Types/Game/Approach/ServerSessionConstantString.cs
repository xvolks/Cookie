using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Approach
{
    public class ServerSessionConstantString : ServerSessionConstant
    {
        public new const ushort ProtocolId = 436;

        public ServerSessionConstantString(string value)
        {
            Value = value;
        }

        public ServerSessionConstantString()
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