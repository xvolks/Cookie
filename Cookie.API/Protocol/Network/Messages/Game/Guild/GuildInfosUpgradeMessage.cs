using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInfosUpgradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5636;

        public GuildInfosUpgradeMessage(byte maxTaxCollectorsCount, byte taxCollectorsCount,
            ushort taxCollectorLifePoints, ushort taxCollectorDamagesBonuses, ushort taxCollectorPods,
            ushort taxCollectorProspecting, ushort taxCollectorWisdom, ushort boostPoints, List<ushort> spellId,
            List<short> spellLevel)
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

        public GuildInfosUpgradeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte MaxTaxCollectorsCount { get; set; }
        public byte TaxCollectorsCount { get; set; }
        public ushort TaxCollectorLifePoints { get; set; }
        public ushort TaxCollectorDamagesBonuses { get; set; }
        public ushort TaxCollectorPods { get; set; }
        public ushort TaxCollectorProspecting { get; set; }
        public ushort TaxCollectorWisdom { get; set; }
        public ushort BoostPoints { get; set; }
        public List<ushort> SpellId { get; set; }
        public List<short> SpellLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(MaxTaxCollectorsCount);
            writer.WriteByte(TaxCollectorsCount);
            writer.WriteVarUhShort(TaxCollectorLifePoints);
            writer.WriteVarUhShort(TaxCollectorDamagesBonuses);
            writer.WriteVarUhShort(TaxCollectorPods);
            writer.WriteVarUhShort(TaxCollectorProspecting);
            writer.WriteVarUhShort(TaxCollectorWisdom);
            writer.WriteVarUhShort(BoostPoints);
            writer.WriteShort((short) SpellId.Count);
            for (var spellIdIndex = 0; spellIdIndex < SpellId.Count; spellIdIndex++)
                writer.WriteVarUhShort(SpellId[spellIdIndex]);
            writer.WriteShort((short) SpellLevel.Count);
            for (var spellLevelIndex = 0; spellLevelIndex < SpellLevel.Count; spellLevelIndex++)
                writer.WriteShort(SpellLevel[spellLevelIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            MaxTaxCollectorsCount = reader.ReadByte();
            TaxCollectorsCount = reader.ReadByte();
            TaxCollectorLifePoints = reader.ReadVarUhShort();
            TaxCollectorDamagesBonuses = reader.ReadVarUhShort();
            TaxCollectorPods = reader.ReadVarUhShort();
            TaxCollectorProspecting = reader.ReadVarUhShort();
            TaxCollectorWisdom = reader.ReadVarUhShort();
            BoostPoints = reader.ReadVarUhShort();
            var spellIdCount = reader.ReadUShort();
            SpellId = new List<ushort>();
            for (var spellIdIndex = 0; spellIdIndex < spellIdCount; spellIdIndex++)
                SpellId.Add(reader.ReadVarUhShort());
            var spellLevelCount = reader.ReadUShort();
            SpellLevel = new List<short>();
            for (var spellLevelIndex = 0; spellLevelIndex < spellLevelCount; spellLevelIndex++)
                SpellLevel.Add(reader.ReadShort());
        }
    }
}