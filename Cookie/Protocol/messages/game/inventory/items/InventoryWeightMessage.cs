using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InventoryWeightMessage : NetworkMessage
    {
        public const uint ProtocolId = 3009;
        public override uint MessageID { get { return ProtocolId; } }

        public int Weight = 0;
        public int WeightMax = 0;

        public InventoryWeightMessage()
        {
        }

        public InventoryWeightMessage(
            int weight,
            int weightMax
        )
        {
            Weight = weight;
            WeightMax = weightMax;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Weight);
            writer.WriteVarInt(WeightMax);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Weight = reader.ReadVarInt();
            WeightMax = reader.ReadVarInt();
        }
    }
}