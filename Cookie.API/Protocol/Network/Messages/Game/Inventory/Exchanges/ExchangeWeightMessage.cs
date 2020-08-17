using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeWeightMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5793;

        public ExchangeWeightMessage(uint currentWeight, uint maxWeight)
        {
            CurrentWeight = currentWeight;
            MaxWeight = maxWeight;
        }

        public ExchangeWeightMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint CurrentWeight { get; set; }
        public uint MaxWeight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(CurrentWeight);
            writer.WriteVarUhInt(MaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            CurrentWeight = reader.ReadVarUhInt();
            MaxWeight = reader.ReadVarUhInt();
        }
    }
}