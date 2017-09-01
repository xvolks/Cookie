using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5946;

        public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
        {
            SellerId = sellerId;
        }

        public ExchangeBidHouseItemRemoveOkMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int SellerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SellerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerId = reader.ReadInt();
        }
    }
}