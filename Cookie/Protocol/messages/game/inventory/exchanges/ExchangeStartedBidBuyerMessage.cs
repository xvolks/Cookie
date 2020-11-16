using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedBidBuyerMessage : NetworkMessage
    {
        public const uint ProtocolId = 5904;
        public override uint MessageID { get { return ProtocolId; } }

        public SellerBuyerDescriptor BuyerDescriptor;

        public ExchangeStartedBidBuyerMessage()
        {
        }

        public ExchangeStartedBidBuyerMessage(
            SellerBuyerDescriptor buyerDescriptor
        )
        {
            BuyerDescriptor = buyerDescriptor;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            BuyerDescriptor.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BuyerDescriptor = new SellerBuyerDescriptor();
            BuyerDescriptor.Deserialize(reader);
        }
    }
}