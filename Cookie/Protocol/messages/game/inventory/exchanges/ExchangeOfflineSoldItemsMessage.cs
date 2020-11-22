using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeOfflineSoldItemsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6613;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItemGenericQuantityPrice> BidHouseItems;
        public List<ObjectItemGenericQuantityPrice> MerchantItems;

        public ExchangeOfflineSoldItemsMessage()
        {
        }

        public ExchangeOfflineSoldItemsMessage(
            List<ObjectItemGenericQuantityPrice> bidHouseItems,
            List<ObjectItemGenericQuantityPrice> merchantItems
        )
        {
            BidHouseItems = bidHouseItems;
            MerchantItems = merchantItems;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)BidHouseItems.Count());
            foreach (var current in BidHouseItems)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)MerchantItems.Count());
            foreach (var current in MerchantItems)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countBidHouseItems = reader.ReadShort();
            BidHouseItems = new List<ObjectItemGenericQuantityPrice>();
            for (short i = 0; i < countBidHouseItems; i++)
            {
                ObjectItemGenericQuantityPrice type = new ObjectItemGenericQuantityPrice();
                type.Deserialize(reader);
                BidHouseItems.Add(type);
            }
            var countMerchantItems = reader.ReadShort();
            MerchantItems = new List<ObjectItemGenericQuantityPrice>();
            for (short i = 0; i < countMerchantItems; i++)
            {
                ObjectItemGenericQuantityPrice type = new ObjectItemGenericQuantityPrice();
                type.Deserialize(reader);
                MerchantItems.Add(type);
            }
        }
    }
}