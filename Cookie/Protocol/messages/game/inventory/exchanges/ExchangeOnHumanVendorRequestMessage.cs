using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5772;
        public override uint MessageID { get { return ProtocolId; } }

        public long HumanVendorId = 0;
        public short HumanVendorCell = 0;

        public ExchangeOnHumanVendorRequestMessage()
        {
        }

        public ExchangeOnHumanVendorRequestMessage(
            long humanVendorId,
            short humanVendorCell
        )
        {
            HumanVendorId = humanVendorId;
            HumanVendorCell = humanVendorCell;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(HumanVendorId);
            writer.WriteVarShort(HumanVendorCell);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HumanVendorId = reader.ReadVarLong();
            HumanVendorCell = reader.ReadVarShort();
        }
    }
}