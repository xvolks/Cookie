using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class IndexedEntityLook : NetworkType
    {
        public const ushort ProtocolId = 405;

        public override ushort TypeID => ProtocolId;

        public EntityLook Look { get; set; }
        public sbyte Index { get; set; }
        public IndexedEntityLook() { }

        public IndexedEntityLook( EntityLook Look, sbyte Index ){
            this.Look = Look;
            this.Index = Index;
        }

        public override void Serialize(IDataWriter writer)
        {
            Look.Serialize(writer);
            writer.WriteSByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
            Index = reader.ReadSByte();
        }
    }
}
