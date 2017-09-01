using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectMinMax : ObjectEffect
    {
        public new const ushort ProtocolId = 82;

        public ObjectEffectMinMax(uint min, uint max)
        {
            Min = min;
            Max = max;
        }

        public ObjectEffectMinMax()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint Min { get; set; }
        public uint Max { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Min);
            writer.WriteVarUhInt(Max);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Min = reader.ReadVarUhInt();
            Max = reader.ReadVarUhInt();
        }
    }
}