using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class SubEntity : NetworkType
    {
        public const short ProtocolId = 54;
        public override short TypeId { get { return ProtocolId; } }

        public byte BindingPointCategory = 0;
        public byte BindingPointIndex = 0;
        public EntityLook SubEntityLook;

        public SubEntity()
        {
        }

        public SubEntity(
            byte bindingPointCategory,
            byte bindingPointIndex,
            EntityLook subEntityLook
        )
        {
            BindingPointCategory = bindingPointCategory;
            BindingPointIndex = bindingPointIndex;
            SubEntityLook = subEntityLook;
        }

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