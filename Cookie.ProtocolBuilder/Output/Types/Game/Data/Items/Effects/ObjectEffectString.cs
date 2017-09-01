namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    using Utils.IO;

    public class ObjectEffectString : ObjectEffect
    {
        public new const ushort ProtocolId = 74;
        public override ushort TypeID => ProtocolId;
        public string Value { get; set; }

        public ObjectEffectString(string value)
        {
            Value = value;
        }

        public ObjectEffectString() { }

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
