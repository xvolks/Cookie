using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
    {
        public new const ushort ProtocolId = 5615;

        public override ushort MessageID => ProtocolId;

        public ushort MaxPods { get; set; }
        public ushort Prospecting { get; set; }
        public ushort Wisdom { get; set; }
        public sbyte TaxCollectorsCount { get; set; }
        public int TaxCollectorAttack { get; set; }
        public ulong Kamas { get; set; }
        public ulong Experience { get; set; }
        public uint Pods { get; set; }
        public ulong ItemsValue { get; set; }
        public TaxCollectorDialogQuestionExtendedMessage() { }

        public TaxCollectorDialogQuestionExtendedMessage( ushort MaxPods, ushort Prospecting, ushort Wisdom, sbyte TaxCollectorsCount, int TaxCollectorAttack, ulong Kamas, ulong Experience, uint Pods, ulong ItemsValue ){
            this.MaxPods = MaxPods;
            this.Prospecting = Prospecting;
            this.Wisdom = Wisdom;
            this.TaxCollectorsCount = TaxCollectorsCount;
            this.TaxCollectorAttack = TaxCollectorAttack;
            this.Kamas = Kamas;
            this.Experience = Experience;
            this.Pods = Pods;
            this.ItemsValue = ItemsValue;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(MaxPods);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteVarUhShort(Wisdom);
            writer.WriteSByte(TaxCollectorsCount);
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
            TaxCollectorsCount = reader.ReadSByte();
            TaxCollectorAttack = reader.ReadInt();
            Kamas = reader.ReadVarUhLong();
            Experience = reader.ReadVarUhLong();
            Pods = reader.ReadVarUhInt();
            ItemsValue = reader.ReadVarUhLong();
        }
    }
}
