using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
    {
        public new const ushort ProtocolId = 5514;

        public override ushort MessageID => ProtocolId;

        public ulong Price { get; set; }
        public ExchangeObjectMovePricedMessage() { }

        public ExchangeObjectMovePricedMessage( ulong Price ){
            this.Price = Price;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Price = reader.ReadVarUhLong();
        }
    }
}
