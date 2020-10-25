using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ItemDurability : NetworkType
    {
        public const short ProtocolId = 168;
        public override short TypeId { get { return ProtocolId; } }

        public short Durability = 0;
        public short DurabilityMax = 0;

        public ItemDurability()
        {
        }

        public ItemDurability(
            short durability,
            short durabilityMax
        )
        {
            Durability = durability;
            DurabilityMax = durabilityMax;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Durability);
            writer.WriteShort(DurabilityMax);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Durability = reader.ReadShort();
            DurabilityMax = reader.ReadShort();
        }
    }
}