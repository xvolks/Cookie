using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    public class ShortcutBarAddRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6225;

        public ShortcutBarAddRequestMessage(byte barType, Types.Game.Shortcut.Shortcut shortcut)
        {
            BarType = barType;
            Shortcut = shortcut;
        }

        public ShortcutBarAddRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public Types.Game.Shortcut.Shortcut Shortcut { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteUShort(Shortcut.TypeID);
            Shortcut.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            Shortcut = ProtocolTypeManager.GetInstance<Types.Game.Shortcut.Shortcut>(reader.ReadUShort());
            Shortcut.Deserialize(reader);
        }
    }
}