using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
    {
        public new const ushort ProtocolId = 372;

        public override ushort TypeID => ProtocolId;

        public ulong Kamas { get; set; }
        public ulong Experience { get; set; }
        public uint Pods { get; set; }
        public ulong ItemsValue { get; set; }
        public TaxCollectorLootInformations() { }

        public TaxCollectorLootInformations( ulong Kamas, ulong Experience, uint Pods, ulong ItemsValue ){
            this.Kamas = Kamas;
            this.Experience = Experience;
            this.Pods = Pods;
            this.ItemsValue = ItemsValue;
        }

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
