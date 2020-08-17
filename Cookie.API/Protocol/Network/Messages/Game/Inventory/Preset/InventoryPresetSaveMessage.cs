using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class InventoryPresetSaveMessage : AbstractPresetSaveMessage
    {
        public new const ushort ProtocolId = 6165;

        public InventoryPresetSaveMessage(bool saveEquipment)
        {
            SaveEquipment = saveEquipment;
        }

        public InventoryPresetSaveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool SaveEquipment { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(SaveEquipment);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SaveEquipment = reader.ReadBoolean();
        }
    }
}