using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class SpellListMessage : NetworkMessage
    {
        public const uint ProtocolId = 1200;
        public override uint MessageID { get { return ProtocolId; } }

        public bool SpellPrevisualization = false;
        public List<SpellItem> Spells;

        public SpellListMessage()
        {
        }

        public SpellListMessage(
            bool spellPrevisualization,
            List<SpellItem> spells
        )
        {
            SpellPrevisualization = spellPrevisualization;
            Spells = spells;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(SpellPrevisualization);
            writer.WriteShort((short)Spells.Count());
            foreach (var current in Spells)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellPrevisualization = reader.ReadBoolean();
            var countSpells = reader.ReadShort();
            Spells = new List<SpellItem>();
            for (short i = 0; i < countSpells; i++)
            {
                SpellItem type = new SpellItem();
                type.Deserialize(reader);
                Spells.Add(type);
            }
        }
    }
}