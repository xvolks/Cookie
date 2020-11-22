using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6214;

        public override ushort MessageID => ProtocolId;

        public double MasterId { get; set; }
        public double SlaveId { get; set; }
        public List<SpellItem> SlaveSpells { get; set; }
        public CharacterCharacteristicsInformations SlaveStats { get; set; }
        public List<Shortcut> Shortcuts { get; set; }
        public SlaveSwitchContextMessage() { }

        public SlaveSwitchContextMessage( double MasterId, double SlaveId, List<SpellItem> SlaveSpells, CharacterCharacteristicsInformations SlaveStats, List<Shortcut> Shortcuts ){
            this.MasterId = MasterId;
            this.SlaveId = SlaveId;
            this.SlaveSpells = SlaveSpells;
            this.SlaveStats = SlaveStats;
            this.Shortcuts = Shortcuts;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MasterId);
            writer.WriteDouble(SlaveId);
			writer.WriteShort((short)SlaveSpells.Count);
			foreach (var x in SlaveSpells)
			{
				x.Serialize(writer);
			}
            SlaveStats.Serialize(writer);
			writer.WriteShort((short)Shortcuts.Count);
			foreach (var x in Shortcuts)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            MasterId = reader.ReadDouble();
            SlaveId = reader.ReadDouble();
            var SlaveSpellsCount = reader.ReadShort();
            SlaveSpells = new List<SpellItem>();
            for (var i = 0; i < SlaveSpellsCount; i++)
            {
                var objectToAdd = new SpellItem();
                objectToAdd.Deserialize(reader);
                SlaveSpells.Add(objectToAdd);
            }
            SlaveStats = new CharacterCharacteristicsInformations();
            SlaveStats.Deserialize(reader);
            var ShortcutsCount = reader.ReadShort();
            Shortcuts = new List<Shortcut>();
            for (var i = 0; i < ShortcutsCount; i++)
            {
                Shortcut objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Shortcuts.Add(objectToAdd);
            }
        }
    }
}
