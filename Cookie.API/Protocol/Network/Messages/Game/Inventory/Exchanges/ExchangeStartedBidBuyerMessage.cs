using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartedBidBuyerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5904;

        public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor)
        {
            BuyerDescriptor = buyerDescriptor;
        }

        public ExchangeStartedBidBuyerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public SellerBuyerDescriptor BuyerDescriptor { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            BuyerDescriptor.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BuyerDescriptor = new SellerBuyerDescriptor();
            BuyerDescriptor.Deserialize(reader);
        }
    }
}