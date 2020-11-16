using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class RecycledItem : NetworkType
    {
        public const short ProtocolId = 547;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;
        public uint Qty = 0;

        public RecycledItem()
        {
        }

        public RecycledItem(
            short id_,
            uint qty
        )
        {
            Id_ = id_;
            Qty = qty;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
            writer.WriteUInt(Qty);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
            Qty = reader.ReadUInt();
        }
    }
}