using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartedBidBuyerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5904;

        public override ushort MessageID => ProtocolId;

        public SellerBuyerDescriptor BuyerDescriptor { get; set; }
        public ExchangeStartedBidBuyerMessage() { }

        public ExchangeStartedBidBuyerMessage( SellerBuyerDescriptor BuyerDescriptor ){
            this.BuyerDescriptor = BuyerDescriptor;
        }

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
