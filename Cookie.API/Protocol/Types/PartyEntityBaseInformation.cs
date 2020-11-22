using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyEntityBaseInformation : NetworkType
    {
        public const ushort ProtocolId = 552;

        public override ushort TypeID => ProtocolId;

        public sbyte IndexId { get; set; }
        public sbyte EntityModelId { get; set; }
        public EntityLook EntityLook { get; set; }
        public PartyEntityBaseInformation() { }

        public PartyEntityBaseInformation( sbyte IndexId, sbyte EntityModelId, EntityLook EntityLook ){
            this.IndexId = IndexId;
            this.EntityModelId = EntityModelId;
            this.EntityLook = EntityLook;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(IndexId);
            writer.WriteSByte(EntityModelId);
            EntityLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            IndexId = reader.ReadSByte();
            EntityModelId = reader.ReadSByte();
            EntityLook = new EntityLook();
            EntityLook.Deserialize(reader);
        }
    }
}
