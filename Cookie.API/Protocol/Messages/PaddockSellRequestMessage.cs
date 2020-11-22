using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockSellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5953;

        public override ushort MessageID => ProtocolId;

        public ulong Price { get; set; }
        public bool ForSale { get; set; }
        public PaddockSellRequestMessage() { }

        public PaddockSellRequestMessage( ulong Price, bool ForSale ){
            this.Price = Price;
            this.ForSale = ForSale;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Price);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(IDataReader reader)
        {
            Price = reader.ReadVarUhLong();
            ForSale = reader.ReadBoolean();
        }
    }
}
