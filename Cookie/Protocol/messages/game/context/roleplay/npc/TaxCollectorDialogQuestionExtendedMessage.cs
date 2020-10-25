using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
    {
        public new const uint ProtocolId = 5615;
        public override uint MessageID { get { return ProtocolId; } }

        public short MaxPods = 0;
        public short Prospecting = 0;
        public short Wisdom = 0;
        public byte TaxCollectorsCount = 0;
        public int TaxCollectorAttack = 0;
        public long Kamas = 0;
        public long Experience = 0;
        public int Pods = 0;
        public long ItemsValue = 0;

        public TaxCollectorDialogQuestionExtendedMessage(): base()
        {
        }

        public TaxCollectorDialogQuestionExtendedMessage(
            BasicGuildInformations guildInfo,
            short maxPods,
            short prospecting,
            short wisdom,
            byte taxCollectorsCount,
            int taxCollectorAttack,
            long kamas,
            long experience,
            int pods,
            long itemsValue
        ): base(
            guildInfo
        )
        {
            MaxPods = maxPods;
            Prospecting = prospecting;
            Wisdom = wisdom;
            TaxCollectorsCount = taxCollectorsCount;
            TaxCollectorAttack = taxCollectorAttack;
            Kamas = kamas;
            Experience = experience;
            Pods = pods;
            ItemsValue = itemsValue;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(MaxPods);
            writer.WriteVarShort(Prospecting);
            writer.WriteVarShort(Wisdom);
            writer.WriteByte(TaxCollectorsCount);
            writer.WriteInt(TaxCollectorAttack);
            writer.WriteVarLong(Kamas);
            writer.WriteVarLong(Experience);
            writer.WriteVarInt(Pods);
            writer.WriteVarLong(ItemsValue);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MaxPods = reader.ReadVarShort();
            Prospecting = reader.ReadVarShort();
            Wisdom = reader.ReadVarShort();
            TaxCollectorsCount = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
            Kamas = reader.ReadVarLong();
            Experience = reader.ReadVarLong();
            Pods = reader.ReadVarInt();
            ItemsValue = reader.ReadVarLong();
        }
    }
}