using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeReplyTaxVendorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5787;

        public override ushort MessageID => ProtocolId;

        public ulong ObjectValue { get; set; }
        public ulong TotalTaxValue { get; set; }
        public ExchangeReplyTaxVendorMessage() { }

        public ExchangeReplyTaxVendorMessage( ulong ObjectValue, ulong TotalTaxValue ){
            this.ObjectValue = ObjectValue;
            this.TotalTaxValue = TotalTaxValue;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectValue);
            writer.WriteVarUhLong(TotalTaxValue);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectValue = reader.ReadVarUhLong();
            TotalTaxValue = reader.ReadVarUhLong();
        }
    }
}
