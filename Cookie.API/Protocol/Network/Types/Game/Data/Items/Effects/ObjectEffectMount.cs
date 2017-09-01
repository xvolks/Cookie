using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectMount : ObjectEffect
    {
        public new const ushort ProtocolId = 179;

        public ObjectEffectMount(int mountId, double date, ushort modelId)
        {
            MountId = mountId;
            Date = date;
            ModelId = modelId;
        }

        public ObjectEffectMount()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int MountId { get; set; }
        public double Date { get; set; }
        public ushort ModelId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MountId);
            writer.WriteDouble(Date);
            writer.WriteVarUhShort(ModelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MountId = reader.ReadInt();
            Date = reader.ReadDouble();
            ModelId = reader.ReadVarUhShort();
        }
    }
}