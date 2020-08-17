namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutObjectPreset : ShortcutObject
    {
        public new const ushort ProtocolId = 370;
        public override ushort TypeID => ProtocolId;
        public byte PresetId { get; set; }

        public ShortcutObjectPreset(byte presetId)
        {
            PresetId = presetId;
        }

        public ShortcutObjectPreset() { }

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
