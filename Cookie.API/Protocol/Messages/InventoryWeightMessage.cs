using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InventoryWeightMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3009;

        public override ushort MessageID => ProtocolId;

        public uint Weight { get; set; }
        public uint WeightMax { get; set; }
        public InventoryWeightMessage() { }

        public InventoryWeightMessage( uint Weight, uint WeightMax ){
            this.Weight = Weight;
            this.WeightMax = WeightMax;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Weight);
            writer.WriteVarUhInt(WeightMax);
        }

        public override void Deserialize(IDataReader reader)
        {
            Weight = reader.ReadVarUhInt();
            WeightMax = reader.ReadVarUhInt();
        }
    }
}
