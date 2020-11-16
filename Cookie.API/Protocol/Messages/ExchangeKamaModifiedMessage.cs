using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 5521;

        public override ushort MessageID => ProtocolId;

        public ulong Quantity { get; set; }
        public ExchangeKamaModifiedMessage() { }

        public ExchangeKamaModifiedMessage( ulong Quantity ){
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarUhLong();
        }
    }
}
