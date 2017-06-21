using Cookie.IO;

namespace Cookie.Protocol.Network.Types.Game.Look
{
    public class SubEntity : NetworkType
    {
        public const short ProtocolId = 54;

        public byte BindingPointCategory;
        public byte BindingPointIndex;
        public EntityLook SubEntityLook;

        public SubEntity()
        {
        }

        public SubEntity(byte bindingPointCategory, byte bindingPointIndex, EntityLook subEntityLook)
        {
            BindingPointCategory = bindingPointCategory;
            BindingPointIndex = bindingPointIndex;
            SubEntityLook = subEntityLook;
        }

        public override short TypeID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(BindingPointCategory);
            writer.WriteByte(BindingPointIndex);
            SubEntityLook.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BindingPointCategory = reader.ReadByte();
            BindingPointIndex = reader.ReadByte();
            SubEntityLook = new EntityLook();
            SubEntityLook.Deserialize(reader);
        }
    }
}