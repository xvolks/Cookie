using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    public class SellerBuyerDescriptor : NetworkType
    {
        public const ushort ProtocolId = 121;

        public SellerBuyerDescriptor(List<uint> quantities, List<uint> types, float taxPercentage,
            float taxModificationPercentage, byte maxItemLevel, uint maxItemPerAccount, int npcContextualId,
            ushort unsoldDelay)
        {
            Quantities = quantities;
            Types = types;
            TaxPercentage = taxPercentage;
            TaxModificationPercentage = taxModificationPercentage;
            MaxItemLevel = maxItemLevel;
            MaxItemPerAccount = maxItemPerAccount;
            NpcContextualId = npcContextualId;
            UnsoldDelay = unsoldDelay;
        }

        public SellerBuyerDescriptor()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<uint> Quantities { get; set; }
        public List<uint> Types { get; set; }
        public float TaxPercentage { get; set; }
        public float TaxModificationPercentage { get; set; }
        public byte MaxItemLevel { get; set; }
        public uint MaxItemPerAccount { get; set; }
        public int NpcContextualId { get; set; }
        public ushort UnsoldDelay { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Quantities.Count);
            for (var quantitiesIndex = 0; quantitiesIndex < Quantities.Count; quantitiesIndex++)
                writer.WriteVarUhInt(Quantities[quantitiesIndex]);
            writer.WriteShort((short) Types.Count);
            for (var typesIndex = 0; typesIndex < Types.Count; typesIndex++)
                writer.WriteVarUhInt(Types[typesIndex]);
            writer.WriteFloat(TaxPercentage);
            writer.WriteFloat(TaxModificationPercentage);
            writer.WriteByte(MaxItemLevel);
            writer.WriteVarUhInt(MaxItemPerAccount);
            writer.WriteInt(NpcContextualId);
            writer.WriteVarUhShort(UnsoldDelay);
        }

        public override void Deserialize(IDataReader reader)
        {
            var quantitiesCount = reader.ReadUShort();
            Quantities = new List<uint>();
            for (var quantitiesIndex = 0; quantitiesIndex < quantitiesCount; quantitiesIndex++)
                Quantities.Add(reader.ReadVarUhInt());
            var typesCount = reader.ReadUShort();
            Types = new List<uint>();
            for (var typesIndex = 0; typesIndex < typesCount; typesIndex++)
                Types.Add(reader.ReadVarUhInt());
            TaxPercentage = reader.ReadFloat();
            TaxModificationPercentage = reader.ReadFloat();
            MaxItemLevel = reader.ReadByte();
            MaxItemPerAccount = reader.ReadVarUhInt();
            NpcContextualId = reader.ReadInt();
            UnsoldDelay = reader.ReadVarUhShort();
        }
    }
}