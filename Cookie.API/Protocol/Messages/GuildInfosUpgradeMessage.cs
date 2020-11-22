using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInfosUpgradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5636;

        public override ushort MessageID => ProtocolId;

        public sbyte MaxTaxCollectorsCount { get; set; }
        public sbyte TaxCollectorsCount { get; set; }
        public ushort TaxCollectorLifePoints { get; set; }
        public ushort TaxCollectorDamagesBonuses { get; set; }
        public ushort TaxCollectorPods { get; set; }
        public ushort TaxCollectorProspecting { get; set; }
        public ushort TaxCollectorWisdom { get; set; }
        public ushort BoostPoints { get; set; }
        public List<short> SpellId { get; set; }
        public List<short> SpellLevel { get; set; }
        public GuildInfosUpgradeMessage() { }

        public GuildInfosUpgradeMessage( sbyte MaxTaxCollectorsCount, sbyte TaxCollectorsCount, ushort TaxCollectorLifePoints, ushort TaxCollectorDamagesBonuses, ushort TaxCollectorPods, ushort TaxCollectorProspecting, ushort TaxCollectorWisdom, ushort BoostPoints, List<short> SpellId, List<short> SpellLevel ){
            this.MaxTaxCollectorsCount = MaxTaxCollectorsCount;
            this.TaxCollectorsCount = TaxCollectorsCount;
            this.TaxCollectorLifePoints = TaxCollectorLifePoints;
            this.TaxCollectorDamagesBonuses = TaxCollectorDamagesBonuses;
            this.TaxCollectorPods = TaxCollectorPods;
            this.TaxCollectorProspecting = TaxCollectorProspecting;
            this.TaxCollectorWisdom = TaxCollectorWisdom;
            this.BoostPoints = BoostPoints;
            this.SpellId = SpellId;
            this.SpellLevel = SpellLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(MaxTaxCollectorsCount);
            writer.WriteSByte(TaxCollectorsCount);
            writer.WriteVarUhShort(TaxCollectorLifePoints);
            writer.WriteVarUhShort(TaxCollectorDamagesBonuses);
            writer.WriteVarUhShort(TaxCollectorPods);
            writer.WriteVarUhShort(TaxCollectorProspecting);
            writer.WriteVarUhShort(TaxCollectorWisdom);
            writer.WriteVarUhShort(BoostPoints);
			writer.WriteShort((short)SpellId.Count);
			foreach (var x in SpellId)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)SpellLevel.Count);
			foreach (var x in SpellLevel)
			{
				writer.WriteShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            MaxTaxCollectorsCount = reader.ReadSByte();
            TaxCollectorsCount = reader.ReadSByte();
            TaxCollectorLifePoints = reader.ReadVarUhShort();
            TaxCollectorDamagesBonuses = reader.ReadVarUhShort();
            TaxCollectorPods = reader.ReadVarUhShort();
            TaxCollectorProspecting = reader.ReadVarUhShort();
            TaxCollectorWisdom = reader.ReadVarUhShort();
            BoostPoints = reader.ReadVarUhShort();
            var SpellIdCount = reader.ReadShort();
            SpellId = new List<short>();
            for (var i = 0; i < SpellIdCount; i++)
            {
                SpellId.Add(reader.ReadVarShort());
            }
            var SpellLevelCount = reader.ReadShort();
            SpellLevel = new List<short>();
            for (var i = 0; i < SpellLevelCount; i++)
            {
                SpellLevel.Add(reader.ReadShort());
            }
        }
    }
}
