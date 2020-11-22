using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class SpellsPreset : Preset
    {
        public new const short ProtocolId = 519;
        public override short TypeId { get { return ProtocolId; } }

        public List<SpellForPreset> Spells;

        public SpellsPreset(): base()
        {
        }

        public SpellsPreset(
            short id_,
            List<SpellForPreset> spells
        ): base(
            id_
        )
        {
            Spells = spells;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Spells.Count());
            foreach (var current in Spells)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countSpells = reader.ReadShort();
            Spells = new List<SpellForPreset>();
            for (short i = 0; i < countSpells; i++)
            {
                SpellForPreset type = new SpellForPreset();
                type.Deserialize(reader);
                Spells.Add(type);
            }
        }
    }
}