using Cookie.API.Protocol.Network.Types.Game.Inventory.Preset;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class InventoryPresetItemUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6168;

        public InventoryPresetItemUpdateMessage(byte presetId, PresetItem presetItem)
        {
            PresetId = presetId;
            PresetItem = presetItem;
        }

        public InventoryPresetItemUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public PresetItem PresetItem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            PresetItem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            PresetItem = new PresetItem();
            PresetItem.Deserialize(reader);
        }
    }
}