using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Shortcut
{
    public class ShortcutBarContentMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6231;

        public ShortcutBarContentMessage(byte barType, List<Types.Game.Shortcut.Shortcut> shortcuts)
        {
            BarType = barType;
            Shortcuts = shortcuts;
        }

        public ShortcutBarContentMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public List<Types.Game.Shortcut.Shortcut> Shortcuts { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteShort((short) Shortcuts.Count);
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
            Shortcuts = new List<Types.Game.Shortcut.Shortcut>();
            for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Types.Game.Shortcut.Shortcut>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Shortcuts.Add(objectToAdd);
            }
        }
    }
}