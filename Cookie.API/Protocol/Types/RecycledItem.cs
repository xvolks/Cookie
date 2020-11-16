using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class RecycledItem : NetworkType
    {
        public const ushort ProtocolId = 547;

        public override ushort TypeID => ProtocolId;

        public ushort Id { get; set; }
        public uint Qty { get; set; }
        public RecycledItem() { }

        public RecycledItem( ushort Id, uint Qty ){
            this.Id = Id;
            this.Qty = Qty;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
            writer.WriteUnsignedInt(Qty);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
            Qty = reader.ReadUnsignedInt();
        }
    }
}
