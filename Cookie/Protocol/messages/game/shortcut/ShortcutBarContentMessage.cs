using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ShortcutBarContentMessage : NetworkMessage
    {
        public const uint ProtocolId = 6231;
        public override uint MessageID { get { return ProtocolId; } }

        public byte BarType = 0;
        public List<Shortcut> Shortcuts;

        public ShortcutBarContentMessage()
        {
        }

        public ShortcutBarContentMessage(
            byte barType,
            List<Shortcut> shortcuts
        )
        {
            BarType = barType;
            Shortcuts = shortcuts;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(BarType);
            writer.WriteShort((short)Shortcuts.Count());
            foreach (var current in Shortcuts)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BarType = reader.ReadByte();
            var countShortcuts = reader.ReadShort();
            Shortcuts = new List<Shortcut>();
            for (short i = 0; i < countShortcuts; i++)
            {
                var shortcutstypeId = reader.ReadShort();
                Shortcut type = new Shortcut();
                type.Deserialize(reader);
                Shortcuts.Add(type);
            }
        }
    }
}