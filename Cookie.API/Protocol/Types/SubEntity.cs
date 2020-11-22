using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SubEntity : NetworkType
    {
        public const ushort ProtocolId = 54;

        public override ushort TypeID => ProtocolId;

        public sbyte BindingPointCategory { get; set; }
        public sbyte BindingPointIndex { get; set; }
        public EntityLook SubEntityLook { get; set; }
        public SubEntity() { }

        public SubEntity( sbyte BindingPointCategory, sbyte BindingPointIndex, EntityLook SubEntityLook ){
            this.BindingPointCategory = BindingPointCategory;
            this.BindingPointIndex = BindingPointIndex;
            this.SubEntityLook = SubEntityLook;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(BindingPointCategory);
            writer.WriteSByte(BindingPointIndex);
            SubEntityLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BindingPointCategory = reader.ReadSByte();
            BindingPointIndex = reader.ReadSByte();
            SubEntityLook = new EntityLook();
            SubEntityLook.Deserialize(reader);
        }
    }
}
