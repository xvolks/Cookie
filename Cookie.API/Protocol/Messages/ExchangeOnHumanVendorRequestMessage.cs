using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5772;

        public override ushort MessageID => ProtocolId;

        public ulong HumanVendorId { get; set; }
        public ushort HumanVendorCell { get; set; }
        public ExchangeOnHumanVendorRequestMessage() { }

        public ExchangeOnHumanVendorRequestMessage( ulong HumanVendorId, ushort HumanVendorCell ){
            this.HumanVendorId = HumanVendorId;
            this.HumanVendorCell = HumanVendorCell;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(HumanVendorId);
            writer.WriteVarUhShort(HumanVendorCell);
        }

        public override void Deserialize(IDataReader reader)
        {
            HumanVendorId = reader.ReadVarUhLong();
            HumanVendorCell = reader.ReadVarUhShort();
        }
    }
}
