using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ItemForPreset : NetworkType
    {
        public const short ProtocolId = 540;
        public override short TypeId { get { return ProtocolId; } }

        public short Position = 63;
        public short ObjGid = 0;
        public int ObjUid = 0;

        public ItemForPreset()
        {
        }

        public ItemForPreset(
            short position,
            short objGid,
            int objUid
        )
        {
            Position = position;
            ObjGid = objGid;
            ObjUid = objUid;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Position);
            writer.WriteVarShort(ObjGid);
            writer.WriteVarInt(ObjUid);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Position = reader.ReadShort();
            ObjGid = reader.ReadVarShort();
            ObjUid = reader.ReadVarInt();
        }
    }
}