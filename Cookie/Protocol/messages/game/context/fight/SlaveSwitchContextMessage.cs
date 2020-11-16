using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const uint ProtocolId = 6214;
        public override uint MessageID { get { return ProtocolId; } }

        public double MasterId = 0;
        public double SlaveId = 0;
        public List<SpellItem> SlaveSpells;
        public CharacterCharacteristicsInformations SlaveStats;
        public List<Shortcut> Shortcuts;

        public SlaveSwitchContextMessage()
        {
        }

        public SlaveSwitchContextMessage(
            double masterId,
            double slaveId,
            List<SpellItem> slaveSpells,
            CharacterCharacteristicsInformations slaveStats,
            List<Shortcut> shortcuts
        )
        {
            MasterId = masterId;
            SlaveId = slaveId;
            SlaveSpells = slaveSpells;
            SlaveStats = slaveStats;
            Shortcuts = shortcuts;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MasterId);
            writer.WriteDouble(SlaveId);
            writer.WriteShort((short)SlaveSpells.Count());
            foreach (var current in SlaveSpells)
            {
                current.Serialize(writer);
            }
            SlaveStats.Serialize(writer);
            writer.WriteShort((short)Shortcuts.Count());
            foreach (var current in Shortcuts)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MasterId = reader.ReadDouble();
            SlaveId = reader.ReadDouble();
            var countSlaveSpells = reader.ReadShort();
            SlaveSpells = new List<SpellItem>();
            for (short i = 0; i < countSlaveSpells; i++)
            {
                SpellItem type = new SpellItem();
                type.Deserialize(reader);
                SlaveSpells.Add(type);
            }
            SlaveStats = new CharacterCharacteristicsInformations();
            SlaveStats.Deserialize(reader);
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