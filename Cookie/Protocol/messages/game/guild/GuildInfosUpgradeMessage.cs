using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInfosUpgradeMessage : NetworkMessage
    {
        public const uint ProtocolId = 5636;
        public override uint MessageID { get { return ProtocolId; } }

        public byte MaxTaxCollectorsCount = 0;
        public byte TaxCollectorsCount = 0;
        public short TaxCollectorLifePoints = 0;
        public short TaxCollectorDamagesBonuses = 0;
        public short TaxCollectorPods = 0;
        public short TaxCollectorProspecting = 0;
        public short TaxCollectorWisdom = 0;
        public short BoostPoints = 0;
        public List<short> SpellId;
        public List<short> SpellLevel;

        public GuildInfosUpgradeMessage()
        {
        }

        public GuildInfosUpgradeMessage(
            byte maxTaxCollectorsCount,
            byte taxCollectorsCount,
            short taxCollectorLifePoints,
            short taxCollectorDamagesBonuses,
            short taxCollectorPods,
            short taxCollectorProspecting,
            short taxCollectorWisdom,
            short boostPoints,
            List<short> spellId,
            List<short> spellLevel
        )
        {
            MaxTaxCollectorsCount = maxTaxCollectorsCount;
            TaxCollectorsCount = taxCollectorsCount;
            TaxCollectorLifePoints = taxCollectorLifePoints;
            TaxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
            TaxCollectorPods = taxCollectorPods;
            TaxCollectorProspecting = taxCollectorProspecting;
            TaxCollectorWisdom = taxCollectorWisdom;
            BoostPoints = boostPoints;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(MaxTaxCollectorsCount);
            writer.WriteByte(TaxCollectorsCount);
            writer.WriteVarShort(TaxCollectorLifePoints);
            writer.WriteVarShort(TaxCollectorDamagesBonuses);
            writer.WriteVarShort(TaxCollectorPods);
            writer.WriteVarShort(TaxCollectorProspecting);
            writer.WriteVarShort(TaxCollectorWisdom);
            writer.WriteVarShort(BoostPoints);
            writer.WriteShort((short)SpellId.Count());
            foreach (var current in SpellId)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)SpellLevel.Count());
            foreach (var current in SpellLevel)
            {
                writer.WriteShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MaxTaxCollectorsCount = reader.ReadByte();
            TaxCollectorsCount = reader.ReadByte();
            TaxCollectorLifePoints = reader.ReadVarShort();
            TaxCollectorDamagesBonuses = reader.ReadVarShort();
            TaxCollectorPods = reader.ReadVarShort();
            TaxCollectorProspecting = reader.ReadVarShort();
            TaxCollectorWisdom = reader.ReadVarShort();
            BoostPoints = reader.ReadVarShort();
            var countSpellId = reader.ReadShort();
            SpellId = new List<short>();
            for (short i = 0; i < countSpellId; i++)
            {
                SpellId.Add(reader.ReadVarShort());
            }
            var countSpellLevel = reader.ReadShort();
            SpellLevel = new List<short>();
            for (short i = 0; i < countSpellLevel; i++)
            {
                SpellLevel.Add(reader.ReadShort());
            }
        }
    }
}