using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    public class IdolsPresetUseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6615;

        public IdolsPresetUseMessage(byte presetId, bool party)
        {
            PresetId = presetId;
            Party = party;
        }

        public IdolsPresetUseMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public bool Party { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteBoolean(Party);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Party = reader.ReadBoolean();
        }
    }
}