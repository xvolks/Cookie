using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeOfflineSoldItemsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6613;

        public ExchangeOfflineSoldItemsMessage(List<ObjectItemGenericQuantityPrice> bidHouseItems,
            List<ObjectItemGenericQuantityPrice> merchantItems)
        {
            BidHouseItems = bidHouseItems;
            MerchantItems = merchantItems;
        }

        public ExchangeOfflineSoldItemsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ObjectItemGenericQuantityPrice> BidHouseItems { get; set; }
        public List<ObjectItemGenericQuantityPrice> MerchantItems { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) BidHouseItems.Count);
            for (var bidHouseItemsIndex = 0; bidHouseItemsIndex < BidHouseItems.Count; bidHouseItemsIndex++)
            {
                var objectToSend = BidHouseItems[bidHouseItemsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) MerchantItems.Count);
            for (var merchantItemsIndex = 0; merchantItemsIndex < MerchantItems.Count; merchantItemsIndex++)
            {
                var objectToSend = MerchantItems[merchantItemsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var bidHouseItemsCount = reader.ReadUShort();
            BidHouseItems = new List<ObjectItemGenericQuantityPrice>();
            for (var bidHouseItemsIndex = 0; bidHouseItemsIndex < bidHouseItemsCount; bidHouseItemsIndex++)
            {
                var objectToAdd = new ObjectItemGenericQuantityPrice();
                objectToAdd.Deserialize(reader);
                BidHouseItems.Add(objectToAdd);
            }
            var merchantItemsCount = reader.ReadUShort();
            MerchantItems = new List<ObjectItemGenericQuantityPrice>();
            for (var merchantItemsIndex = 0; merchantItemsIndex < merchantItemsCount; merchantItemsIndex++)
            {
                var objectToAdd = new ObjectItemGenericQuantityPrice();
                objectToAdd.Deserialize(reader);
                MerchantItems.Add(objectToAdd);
            }
        }
    }
}