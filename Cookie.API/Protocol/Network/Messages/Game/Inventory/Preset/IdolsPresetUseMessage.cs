namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Utils.IO;

    public class IdolsPresetUseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6615;
        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public bool Party { get; set; }

        public IdolsPresetUseMessage(byte presetId, bool party)
        {
            PresetId = presetId;
            Party = party;
        }

        public IdolsPresetUseMessage() { }

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
