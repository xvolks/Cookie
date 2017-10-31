namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeSellMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5778;
        public override ushort MessageID => ProtocolId;
        public uint ObjectToSellId { get; set; }
        public uint Quantity { get; set; }

        public ExchangeSellMessage(uint objectToSellId, uint quantity)
        {
            ObjectToSellId = objectToSellId;
            Quantity = quantity;
        }

        public ExchangeSellMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectToSellId);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectToSellId = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }

    }
}
