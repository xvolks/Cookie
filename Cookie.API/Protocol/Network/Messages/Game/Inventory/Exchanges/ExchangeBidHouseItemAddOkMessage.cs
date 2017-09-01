using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5945;

        public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
        {
            ItemInfo = itemInfo;
        }

        public ExchangeBidHouseItemAddOkMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ObjectItemToSellInBid ItemInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            ItemInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemInfo = new ObjectItemToSellInBid();
            ItemInfo.Deserialize(reader);
        }
    }
}