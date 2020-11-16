using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemInRolePlay : NetworkType
    {
        public const ushort ProtocolId = 198;

        public override ushort TypeID => ProtocolId;

        public ushort CellId { get; set; }
        public ushort ObjectGID { get; set; }
        public ObjectItemInRolePlay() { }

        public ObjectItemInRolePlay( ushort CellId, ushort ObjectGID ){
            this.CellId = CellId;
            this.ObjectGID = ObjectGID;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}
