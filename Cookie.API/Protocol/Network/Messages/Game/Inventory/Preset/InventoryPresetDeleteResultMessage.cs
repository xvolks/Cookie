using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class InventoryPresetDeleteResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6173;

        public InventoryPresetDeleteResultMessage(byte presetId, byte code)
        {
            PresetId = presetId;
            Code = code;
        }

        public InventoryPresetDeleteResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte Code { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Code = reader.ReadByte();
        }
    }
}