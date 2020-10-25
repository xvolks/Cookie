using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
    {
        public const uint ProtocolId = 5946;
        public override uint MessageID { get { return ProtocolId; } }

        public int SellerId = 0;

        public ExchangeBidHouseItemRemoveOkMessage()
        {
        }

        public ExchangeBidHouseItemRemoveOkMessage(
            int sellerId
        )
        {
            SellerId = sellerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(SellerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SellerId = reader.ReadInt();
        }
    }
}