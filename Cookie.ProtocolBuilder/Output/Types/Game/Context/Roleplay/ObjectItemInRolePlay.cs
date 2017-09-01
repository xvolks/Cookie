namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class ObjectItemInRolePlay : NetworkType
    {
        public const ushort ProtocolId = 198;
        public override ushort TypeID => ProtocolId;
        public ushort CellId { get; set; }
        public ushort ObjectGID { get; set; }

        public ObjectItemInRolePlay(ushort cellId, ushort objectGID)
        {
            CellId = cellId;
            ObjectGID = objectGID;
        }

        public ObjectItemInRolePlay() { }

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
