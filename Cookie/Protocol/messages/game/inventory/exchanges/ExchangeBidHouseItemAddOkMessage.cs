using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
    {
        public const uint ProtocolId = 5945;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItemToSellInBid ItemInfo;

        public ExchangeBidHouseItemAddOkMessage()
        {
        }

        public ExchangeBidHouseItemAddOkMessage(
            ObjectItemToSellInBid itemInfo
        )
        {
            ItemInfo = itemInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            ItemInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ItemInfo = new ObjectItemToSellInBid();
            ItemInfo.Deserialize(reader);
        }
    }
}