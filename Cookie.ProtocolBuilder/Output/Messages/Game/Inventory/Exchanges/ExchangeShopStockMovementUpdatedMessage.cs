namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class ExchangeShopStockMovementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5909;
        public override ushort MessageID => ProtocolId;
        public ObjectItemToSell ObjectInfo { get; set; }

        public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo)
        {
            ObjectInfo = objectInfo;
        }

        public ExchangeShopStockMovementUpdatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectInfo = new ObjectItemToSell();
            ObjectInfo.Deserialize(reader);
        }

    }
}
