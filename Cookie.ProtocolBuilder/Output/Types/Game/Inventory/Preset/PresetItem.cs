namespace Cookie.API.Protocol.Network.Types.Game.Inventory.Preset
{
    using Utils.IO;

    public class PresetItem : NetworkType
    {
        public const ushort ProtocolId = 354;
        public override ushort TypeID => ProtocolId;
        public byte Position { get; set; }
        public ushort ObjGid { get; set; }
        public uint ObjUid { get; set; }

        public PresetItem(byte position, ushort objGid, uint objUid)
        {
            Position = position;
            ObjGid = objGid;
            ObjUid = objUid;
        }

        public PresetItem() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Position);
            writer.WriteVarUhShort(ObjGid);
            writer.WriteVarUhInt(ObjUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            Position = reader.ReadByte();
            ObjGid = reader.ReadVarUhShort();
            ObjUid = reader.ReadVarUhInt();
        }

    }
}
