namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutObjectIdolsPreset : ShortcutObject
    {
        public new const ushort ProtocolId = 492;
        public override ushort TypeID => ProtocolId;
        public byte PresetId { get; set; }

        public ShortcutObjectIdolsPreset(byte presetId)
        {
            PresetId = presetId;
        }

        public ShortcutObjectIdolsPreset() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PresetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PresetId = reader.ReadByte();
        }

    }
}
