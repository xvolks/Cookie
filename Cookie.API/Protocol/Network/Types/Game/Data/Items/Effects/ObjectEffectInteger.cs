using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectInteger : ObjectEffect
    {
        public new const ushort ProtocolId = 70;

        public ObjectEffectInteger(uint value)
        {
            Value = value;
        }

        public ObjectEffectInteger()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadVarUhInt();
        }
    }
}