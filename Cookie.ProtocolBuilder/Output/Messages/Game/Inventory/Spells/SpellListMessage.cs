namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Spells
{
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class SpellListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1200;
        public override ushort MessageID => ProtocolId;
        public bool SpellPrevisualization { get; set; }
        public List<SpellItem> Spells { get; set; }

        public SpellListMessage(bool spellPrevisualization, List<SpellItem> spells)
        {
            SpellPrevisualization = spellPrevisualization;
            Spells = spells;
        }

        public SpellListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(SpellPrevisualization);
            writer.WriteShort((short)Spells.Count);
            for (var spellsIndex = 0; spellsIndex < Spells.Count; spellsIndex++)
            {
                var objectToSend = Spells[spellsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellPrevisualization = reader.ReadBoolean();
            var spellsCount = reader.ReadUShort();
            Spells = new List<SpellItem>();
            for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
            {
                var objectToAdd = new SpellItem();
                objectToAdd.Deserialize(reader);
                Spells.Add(objectToAdd);
            }
        }

    }
}
