namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    using Types.Game.Shortcut;
    using System.Collections.Generic;
    using Utils.IO;

    public class ShortcutBarContentMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6231;
        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public List<Shortcut> Shortcuts { get; set; }

        public ShortcutBarContentMessage(byte barType, List<Shortcut> shortcuts)
        {
            BarType = barType;
            Shortcuts = shortcuts;
        }

        public ShortcutBarContentMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteShort((short)Shortcuts.Count);
            for (var shortcutsIndex = 0; shortcutsIndex < Shortcuts.Count; shortcutsIndex++)
            {
                var objectToSend = Shortcuts[shortcutsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            var shortcutsCount = reader.ReadUShort();
            Shortcuts = new List<Shortcut>();
            for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Shortcuts.Add(objectToAdd);
            }
        }

    }
}
