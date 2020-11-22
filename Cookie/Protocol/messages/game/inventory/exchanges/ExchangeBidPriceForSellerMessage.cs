using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
    {
        public new const uint ProtocolId = 6464;
        public override uint MessageID { get { return ProtocolId; } }

        public bool AllIdentical = false;
        public List<long> MinimalPrices;

        public ExchangeBidPriceForSellerMessage(): base()
        {
        }

        public ExchangeBidPriceForSellerMessage(
            short genericId,
            long averagePrice,
            bool allIdentical,
            List<long> minimalPrices
        ): base(
            genericId,
            averagePrice
        )
        {
            AllIdentical = allIdentical;
            MinimalPrices = minimalPrices;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(AllIdentical);
            writer.WriteShort((short)MinimalPrices.Count());
            foreach (var current in MinimalPrices)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllIdentical = reader.ReadBoolean();
            var countMinimalPrices = reader.ReadShort();
            MinimalPrices = new List<long>();
            for (short i = 0; i < countMinimalPrices; i++)
            {
                MinimalPrices.Add(reader.ReadVarLong());
            }
        }
    }
}