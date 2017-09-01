using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class InventoryWeightMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3009;

        public InventoryWeightMessage(uint weight, uint weightMax)
        {
            Weight = weight;
            WeightMax = weightMax;
        }

        public InventoryWeightMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint Weight { get; set; }
        public uint WeightMax { get; set; }

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