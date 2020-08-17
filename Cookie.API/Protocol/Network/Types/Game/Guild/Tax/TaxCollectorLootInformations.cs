using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 372;

        public TaxCollectorLootInformations(ulong kamas, ulong experience, uint pods, ulong itemsValue)
        {
            Kamas = kamas;
            Experience = experience;
            Pods = pods;
            ItemsValue = itemsValue;
        }

        public TaxCollectorLootInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong Kamas { get; set; }
        public ulong Experience { get; set; }
        public uint Pods { get; set; }
        public ulong ItemsValue { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Kamas);
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhInt(Pods);
            writer.WriteVarUhLong(ItemsValue);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Kamas = reader.ReadVarUhLong();
            Experience = reader.ReadVarUhLong();
            Pods = reader.ReadVarUhInt();
            ItemsValue = reader.ReadVarUhLong();
        }
    }
}