namespace Cookie.API.Protocol.Network.Types.Game.Mount
{
    using Utils.IO;

    public class ItemDurability : NetworkType
    {
        public const ushort ProtocolId = 168;
        public override ushort TypeID => ProtocolId;
        public short Durability { get; set; }
        public short DurabilityMax { get; set; }

        public ItemDurability(short durability, short durabilityMax)
        {
            Durability = durability;
            DurabilityMax = durabilityMax;
        }

        public ItemDurability() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Durability);
            writer.WriteShort(DurabilityMax);
        }

        public override void Deserialize(IDataReader reader)
        {
            Durability = reader.ReadShort();
            DurabilityMax = reader.ReadShort();
        }

    }
}
