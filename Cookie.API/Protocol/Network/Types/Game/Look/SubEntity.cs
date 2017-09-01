using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Look
{
    public class SubEntity : NetworkType
    {
        public const ushort ProtocolId = 54;

        public SubEntity(byte bindingPointCategory, byte bindingPointIndex, EntityLook subEntityLook)
        {
            BindingPointCategory = bindingPointCategory;
            BindingPointIndex = bindingPointIndex;
            SubEntityLook = subEntityLook;
        }

        public SubEntity()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte BindingPointCategory { get; set; }
        public byte BindingPointIndex { get; set; }
        public EntityLook SubEntityLook { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BindingPointCategory);
            writer.WriteByte(BindingPointIndex);
            SubEntityLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BindingPointCategory = reader.ReadByte();
            BindingPointIndex = reader.ReadByte();
            SubEntityLook = new EntityLook();
            SubEntityLook.Deserialize(reader);
        }
    }
}