using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidPriceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5755;

        public override ushort MessageID => ProtocolId;

        public ushort GenericId { get; set; }
        public long AveragePrice { get; set; }
        public ExchangeBidPriceMessage() { }

        public ExchangeBidPriceMessage( ushort GenericId, long AveragePrice ){
            this.GenericId = GenericId;
            this.AveragePrice = AveragePrice;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(GenericId);
            writer.WriteVarLong(AveragePrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenericId = reader.ReadVarUhShort();
            AveragePrice = reader.ReadVarLong();
        }
    }
}
