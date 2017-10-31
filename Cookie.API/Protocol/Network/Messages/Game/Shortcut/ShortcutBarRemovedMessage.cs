namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutBarRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6224;
        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public byte Slot { get; set; }

        public ShortcutBarRemovedMessage(byte barType, byte slot)
        {
            BarType = barType;
            Slot = slot;
        }

        public ShortcutBarRemovedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteByte(Slot);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            Slot = reader.ReadByte();
        }

    }
}
