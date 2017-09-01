using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
    {
        public new const ushort ProtocolId = 5615;

        public TaxCollectorDialogQuestionExtendedMessage(ushort maxPods, ushort prospecting, ushort wisdom,
            byte taxCollectorsCount, int taxCollectorAttack, ulong kamas, ulong experience, uint pods, ulong itemsValue)
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

        public TaxCollectorDialogQuestionExtendedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort MaxPods { get; set; }
        public ushort Prospecting { get; set; }
        public ushort Wisdom { get; set; }
        public byte TaxCollectorsCount { get; set; }
        public int TaxCollectorAttack { get; set; }
        public ulong Kamas { get; set; }
        public ulong Experience { get; set; }
        public uint Pods { get; set; }
        public ulong ItemsValue { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(MaxPods);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteVarUhShort(Wisdom);
            writer.WriteByte(TaxCollectorsCount);
            writer.WriteInt(TaxCollectorAttack);
            writer.WriteVarUhLong(Kamas);
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhInt(Pods);
            writer.WriteVarUhLong(ItemsValue);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MaxPods = reader.ReadVarUhShort();
            Prospecting = reader.ReadVarUhShort();
            Wisdom = reader.ReadVarUhShort();
            TaxCollectorsCount = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
            Kamas = reader.ReadVarUhLong();
            Experience = reader.ReadVarUhLong();
            Pods = reader.ReadVarUhInt();
            ItemsValue = reader.ReadVarUhLong();
        }
    }
}