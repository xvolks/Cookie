using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class InventoryPresetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6171;

        public InventoryPresetUpdateMessage(Types.Game.Inventory.Preset.Preset preset)
        {
            Preset = preset;
        }

        public InventoryPresetUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public Types.Game.Inventory.Preset.Preset Preset { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Preset.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Preset = new Types.Game.Inventory.Preset.Preset();
            Preset.Deserialize(reader);
        }
    }
}