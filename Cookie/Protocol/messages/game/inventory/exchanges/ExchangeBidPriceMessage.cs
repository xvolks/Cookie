using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidPriceMessage : NetworkMessage
    {
        public const uint ProtocolId = 5755;
        public override uint MessageID { get { return ProtocolId; } }

        public short GenericId = 0;
        public long AveragePrice = 0;

        public ExchangeBidPriceMessage()
        {
        }

        public ExchangeBidPriceMessage(
            short genericId,
            long averagePrice
        )
        {
            GenericId = genericId;
            AveragePrice = averagePrice;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(GenericId);
            writer.WriteVarLong(AveragePrice);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GenericId = reader.ReadVarShort();
            AveragePrice = reader.ReadVarLong();
        }
    }
}