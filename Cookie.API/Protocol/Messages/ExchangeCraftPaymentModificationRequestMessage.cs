using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCraftPaymentModificationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6579;

        public override ushort MessageID => ProtocolId;

        public ulong Quantity { get; set; }
        public ExchangeCraftPaymentModificationRequestMessage() { }

        public ExchangeCraftPaymentModificationRequestMessage( ulong Quantity ){
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quantity = reader.ReadVarUhLong();
        }
    }
}
