using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ExchangePodsModifiedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6670;

        public ExchangePodsModifiedMessage(uint currentWeight, uint maxWeight)
        {
            CurrentWeight = currentWeight;
            MaxWeight = maxWeight;
        }

        public ExchangePodsModifiedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint CurrentWeight { get; set; }
        public uint MaxWeight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(CurrentWeight);
            writer.WriteVarUhInt(MaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CurrentWeight = reader.ReadVarUhInt();
            MaxWeight = reader.ReadVarUhInt();
        }
    }
}