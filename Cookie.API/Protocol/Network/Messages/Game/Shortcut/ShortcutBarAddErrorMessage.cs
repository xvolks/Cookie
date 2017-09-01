using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    public class ShortcutBarAddErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6227;

        public ShortcutBarAddErrorMessage(byte error)
        {
            Error = error;
        }

        public ShortcutBarAddErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Error { get; set; }

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