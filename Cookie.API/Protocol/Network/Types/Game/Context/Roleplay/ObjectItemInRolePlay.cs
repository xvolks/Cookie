using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class ObjectItemInRolePlay : NetworkType
    {
        public const ushort ProtocolId = 198;

        public ObjectItemInRolePlay(ushort cellId, ushort objectGID)
        {
            CellId = cellId;
            ObjectGID = objectGID;
        }

        public ObjectItemInRolePlay()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort CellId { get; set; }
        public ushort ObjectGID { get; set; }

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