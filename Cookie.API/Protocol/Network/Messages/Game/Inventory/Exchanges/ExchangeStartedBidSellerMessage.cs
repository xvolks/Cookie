using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartedBidSellerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5905;

        public ExchangeStartedBidSellerMessage(SellerBuyerDescriptor sellerDescriptor,
            List<ObjectItemToSellInBid> objectsInfos)
        {
            SellerDescriptor = sellerDescriptor;
            ObjectsInfos = objectsInfos;
        }

        public ExchangeStartedBidSellerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public SellerBuyerDescriptor SellerDescriptor { get; set; }
        public List<ObjectItemToSellInBid> ObjectsInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            SellerDescriptor.Serialize(writer);
            writer.WriteShort((short) ObjectsInfos.Count);
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count; objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerDescriptor = new SellerBuyerDescriptor();
            SellerDescriptor.Deserialize(reader);
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new List<ObjectItemToSellInBid>();
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSellInBid();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}