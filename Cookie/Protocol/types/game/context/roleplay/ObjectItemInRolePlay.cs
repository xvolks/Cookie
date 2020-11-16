using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemInRolePlay : NetworkType
    {
        public const short ProtocolId = 198;
        public override short TypeId { get { return ProtocolId; } }

        public short CellId = 0;
        public short ObjectGID = 0;

        public ObjectItemInRolePlay()
        {
        }

        public ObjectItemInRolePlay(
            short cellId,
            short objectGID
        )
        {
            CellId = cellId;
            ObjectGID = objectGID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CellId);
            writer.WriteVarShort(ObjectGID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellId = reader.ReadVarShort();
            ObjectGID = reader.ReadVarShort();
        }
    }
}