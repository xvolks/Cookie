namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    using Types.Game.Shortcut;
    using Utils.IO;

    public class ShortcutBarAddRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6225;
        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public Shortcut Shortcut { get; set; }

        public ShortcutBarAddRequestMessage(byte barType, Shortcut shortcut)
        {
            BarType = barType;
            Shortcut = shortcut;
        }

        public ShortcutBarAddRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteUShort(Shortcut.TypeID);
            Shortcut.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            Shortcut = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadUShort());
            Shortcut.Deserialize(reader);
        }

    }
}
