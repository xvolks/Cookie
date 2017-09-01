namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Utils.IO;

    public class InventoryPresetUseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6167;
        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }

        public InventoryPresetUseMessage(byte presetId)
        {
            PresetId = presetId;
        }

        public InventoryPresetUseMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
        }

    }
}
