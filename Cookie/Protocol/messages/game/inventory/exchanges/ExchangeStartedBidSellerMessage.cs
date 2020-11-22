using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedBidSellerMessage : NetworkMessage
    {
        public const uint ProtocolId = 5905;
        public override uint MessageID { get { return ProtocolId; } }

        public SellerBuyerDescriptor SellerDescriptor;
        public List<ObjectItemToSellInBid> ObjectsInfos;

        public ExchangeStartedBidSellerMessage()
        {
        }

        public ExchangeStartedBidSellerMessage(
            SellerBuyerDescriptor sellerDescriptor,
            List<ObjectItemToSellInBid> objectsInfos
        )
        {
            SellerDescriptor = sellerDescriptor;
            ObjectsInfos = objectsInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            SellerDescriptor.Serialize(writer);
            writer.WriteShort((short)ObjectsInfos.Count());
            foreach (var current in ObjectsInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SellerDescriptor = new SellerBuyerDescriptor();
            SellerDescriptor.Deserialize(reader);
            var countObjectsInfos = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSellInBid>();
            for (short i = 0; i < countObjectsInfos; i++)
            {
                ObjectItemToSellInBid type = new ObjectItemToSellInBid();
                type.Deserialize(reader);
                ObjectsInfos.Add(type);
            }
        }
    }
}