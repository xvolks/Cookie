using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
    {
        public new const short ProtocolId = 372;
        public override short TypeId { get { return ProtocolId; } }

        public long Kamas = 0;
        public long Experience = 0;
        public int Pods = 0;
        public long ItemsValue = 0;

        public TaxCollectorLootInformations(): base()
        {
        }

        public TaxCollectorLootInformations(
            long kamas,
            long experience,
            int pods,
            long itemsValue
        ): base()
        {
            Kamas = kamas;
            Experience = experience;
            Pods = pods;
            ItemsValue = itemsValue;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Kamas);
            writer.WriteVarLong(Experience);
            writer.WriteVarInt(Pods);
            writer.WriteVarLong(ItemsValue);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Kamas = reader.ReadVarLong();
            Experience = reader.ReadVarLong();
            Pods = reader.ReadVarInt();
            ItemsValue = reader.ReadVarLong();
        }
    }
}