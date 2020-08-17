namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Types.Game.Inventory.Preset;
    using Utils.IO;

    public class InventoryPresetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6171;
        public override ushort MessageID => ProtocolId;
        public Preset Preset { get; set; }

        public InventoryPresetUpdateMessage(Preset preset)
        {
            Preset = preset;
        }

        public InventoryPresetUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Preset.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Preset = new Preset();
            Preset.Deserialize(reader);
        }

    }
}
