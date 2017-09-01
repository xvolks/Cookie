using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5907;

        public ExchangeShopStockMovementRemovedMessage(uint objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeShopStockMovementRemovedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectId { get; set; }

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