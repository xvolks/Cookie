using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5945;

        public override ushort MessageID => ProtocolId;

        public ObjectItemToSellInBid ItemInfo { get; set; }
        public ExchangeBidHouseItemAddOkMessage() { }

        public ExchangeBidHouseItemAddOkMessage( ObjectItemToSellInBid ItemInfo ){
            this.ItemInfo = ItemInfo;
        }

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
