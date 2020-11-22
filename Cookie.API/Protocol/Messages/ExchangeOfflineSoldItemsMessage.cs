using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeOfflineSoldItemsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6613;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItemGenericQuantityPrice> BidHouseItems { get; set; }
        public List<ObjectItemGenericQuantityPrice> MerchantItems { get; set; }
        public ExchangeOfflineSoldItemsMessage() { }

        public ExchangeOfflineSoldItemsMessage( List<ObjectItemGenericQuantityPrice> BidHouseItems, List<ObjectItemGenericQuantityPrice> MerchantItems ){
            this.BidHouseItems = BidHouseItems;
            this.MerchantItems = MerchantItems;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)BidHouseItems.Count);
			foreach (var x in BidHouseItems)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)MerchantItems.Count);
			foreach (var x in MerchantItems)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var BidHouseItemsCount = reader.ReadShort();
            BidHouseItems = new List<ObjectItemGenericQuantityPrice>();
            for (var i = 0; i < BidHouseItemsCount; i++)
            {
                var objectToAdd = new ObjectItemGenericQuantityPrice();
                objectToAdd.Deserialize(reader);
                BidHouseItems.Add(objectToAdd);
            }
            var MerchantItemsCount = reader.ReadShort();
            MerchantItems = new List<ObjectItemGenericQuantityPrice>();
            for (var i = 0; i < MerchantItemsCount; i++)
            {
                var objectToAdd = new ObjectItemGenericQuantityPrice();
                objectToAdd.Deserialize(reader);
                MerchantItems.Add(objectToAdd);
            }
        }
    }
}
