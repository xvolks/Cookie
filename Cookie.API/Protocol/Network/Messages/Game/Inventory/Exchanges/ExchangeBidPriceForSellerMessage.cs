using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
    {
        public new const ushort ProtocolId = 6464;

        public ExchangeBidPriceForSellerMessage(bool allIdentical, List<ulong> minimalPrices)
        {
            AllIdentical = allIdentical;
            MinimalPrices = minimalPrices;
        }

        public ExchangeBidPriceForSellerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool AllIdentical { get; set; }
        public List<ulong> MinimalPrices { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(AllIdentical);
            writer.WriteShort((short) MinimalPrices.Count);
            for (var minimalPricesIndex = 0; minimalPricesIndex < MinimalPrices.Count; minimalPricesIndex++)
                writer.WriteVarUhLong(MinimalPrices[minimalPricesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllIdentical = reader.ReadBoolean();
            var minimalPricesCount = reader.ReadUShort();
            MinimalPrices = new List<ulong>();
            for (var minimalPricesIndex = 0; minimalPricesIndex < minimalPricesCount; minimalPricesIndex++)
                MinimalPrices.Add(reader.ReadVarUhLong());
        }
    }
}