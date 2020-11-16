using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class SpellForPreset : NetworkType
    {
        public const short ProtocolId = 557;
        public override short TypeId { get { return ProtocolId; } }

        public short SpellId = 0;
        public List<short> Shortcuts;

        public SpellForPreset()
        {
        }

        public SpellForPreset(
            short spellId,
            List<short> shortcuts
        )
        {
            SpellId = spellId;
            Shortcuts = shortcuts;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SpellId);
            writer.WriteShort((short)Shortcuts.Count());
            foreach (var current in Shortcuts)
            {
                writer.WriteShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadVarShort();
            var countShortcuts = reader.ReadShort();
            Shortcuts = new List<short>();
            for (short i = 0; i < countShortcuts; i++)
            {
                Shortcuts.Add(reader.ReadShort());
            }
        }
    }
}