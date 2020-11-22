using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
    {
        public new const ushort ProtocolId = 6464;

        public override ushort MessageID => ProtocolId;

        public bool AllIdentical { get; set; }
        public List<long> MinimalPrices { get; set; }
        public ExchangeBidPriceForSellerMessage() { }

        public ExchangeBidPriceForSellerMessage( bool AllIdentical, List<long> MinimalPrices ){
            this.AllIdentical = AllIdentical;
            this.MinimalPrices = MinimalPrices;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(AllIdentical);
			writer.WriteShort((short)MinimalPrices.Count);
			foreach (var x in MinimalPrices)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllIdentical = reader.ReadBoolean();
            var MinimalPricesCount = reader.ReadShort();
            MinimalPrices = new List<long>();
            for (var i = 0; i < MinimalPricesCount; i++)
            {
                MinimalPrices.Add(reader.ReadVarLong());
            }
        }
    }
}
