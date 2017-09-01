namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Utils.IO;

    public class InventoryPresetItemUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6210;
        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte Position { get; set; }
        public uint ObjUid { get; set; }

        public InventoryPresetItemUpdateRequestMessage(byte presetId, byte position, uint objUid)
        {
            PresetId = presetId;
            Position = position;
            ObjUid = objUid;
        }

        public InventoryPresetItemUpdateRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(Position);
            writer.WriteVarUhInt(ObjUid);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Position = reader.ReadByte();
            ObjUid = reader.ReadVarUhInt();
        }

    }
}
