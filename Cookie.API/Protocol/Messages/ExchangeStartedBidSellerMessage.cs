using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartedBidSellerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5905;

        public override ushort MessageID => ProtocolId;

        public SellerBuyerDescriptor SellerDescriptor { get; set; }
        public List<ObjectItemToSellInBid> ObjectsInfos { get; set; }
        public ExchangeStartedBidSellerMessage() { }

        public ExchangeStartedBidSellerMessage( SellerBuyerDescriptor SellerDescriptor, List<ObjectItemToSellInBid> ObjectsInfos ){
            this.SellerDescriptor = SellerDescriptor;
            this.ObjectsInfos = ObjectsInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            SellerDescriptor.Serialize(writer);
			writer.WriteShort((short)ObjectsInfos.Count);
			foreach (var x in ObjectsInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerDescriptor = new SellerBuyerDescriptor();
            SellerDescriptor.Deserialize(reader);
            var ObjectsInfosCount = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSellInBid>();
            for (var i = 0; i < ObjectsInfosCount; i++)
            {
                var objectToAdd = new ObjectItemToSellInBid();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}
