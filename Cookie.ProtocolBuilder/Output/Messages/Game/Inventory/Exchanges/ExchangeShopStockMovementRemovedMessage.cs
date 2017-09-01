namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5907;
        public override ushort MessageID => ProtocolId;
        public uint ObjectId { get; set; }

        public ExchangeShopStockMovementRemovedMessage(uint objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeShopStockMovementRemovedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhInt();
        }

    }
}
