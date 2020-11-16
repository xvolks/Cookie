using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class SellerBuyerDescriptor : NetworkType
    {
        public const short ProtocolId = 121;
        public override short TypeId { get { return ProtocolId; } }

        public List<int> Quantities;
        public List<int> Types;
        public float TaxPercentage = 0;
        public float TaxModificationPercentage = 0;
        public byte MaxItemLevel = 0;
        public int MaxItemPerAccount = 0;
        public int NpcContextualId = 0;
        public short UnsoldDelay = 0;

        public SellerBuyerDescriptor()
        {
        }

        public SellerBuyerDescriptor(
            List<int> quantities,
            List<int> types,
            float taxPercentage,
            float taxModificationPercentage,
            byte maxItemLevel,
            int maxItemPerAccount,
            int npcContextualId,
            short unsoldDelay
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Quantities.Count());
            foreach (var current in Quantities)
            {
                writer.WriteVarInt(current);
            }
            writer.WriteShort((short)Types.Count());
            foreach (var current in Types)
            {
                writer.WriteVarInt(current);
            }
            writer.WriteFloat(TaxPercentage);
            writer.WriteFloat(TaxModificationPercentage);
            writer.WriteByte(MaxItemLevel);
            writer.WriteVarInt(MaxItemPerAccount);
            writer.WriteInt(NpcContextualId);
            writer.WriteVarShort(UnsoldDelay);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countQuantities = reader.ReadShort();
            Quantities = new List<int>();
            for (short i = 0; i < countQuantities; i++)
            {
                Quantities.Add(reader.ReadVarInt());
            }
            var countTypes = reader.ReadShort();
            Types = new List<int>();
            for (short i = 0; i < countTypes; i++)
            {
                Types.Add(reader.ReadVarInt());
            }
            TaxPercentage = reader.ReadFloat();
            TaxModificationPercentage = reader.ReadFloat();
            MaxItemLevel = reader.ReadByte();
            MaxItemPerAccount = reader.ReadVarInt();
            NpcContextualId = reader.ReadInt();
            UnsoldDelay = reader.ReadVarShort();
        }
    }
}