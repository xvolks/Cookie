using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ItemForPreset : NetworkType
    {
        public const ushort ProtocolId = 540;

        public override ushort TypeID => ProtocolId;

        public short Position { get; set; }
        public ushort ObjGid { get; set; }
        public uint ObjUid { get; set; }
        public ItemForPreset() { }

        public ItemForPreset( short Position, ushort ObjGid, uint ObjUid ){
            this.Position = Position;
            this.ObjGid = ObjGid;
            this.ObjUid = ObjUid;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Position);
            writer.WriteVarUhShort(ObjGid);
            writer.WriteVarUhInt(ObjUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            Position = reader.ReadShort();
            ObjGid = reader.ReadVarUhShort();
            ObjUid = reader.ReadVarUhInt();
        }
    }
}
