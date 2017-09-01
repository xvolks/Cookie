namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutBarRemoveErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6222;
        public override ushort MessageID => ProtocolId;
        public byte Error { get; set; }

        public ShortcutBarRemoveErrorMessage(byte error)
        {
            Error = error;
        }

        public ShortcutBarRemoveErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadByte();
        }

    }
}
