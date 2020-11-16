using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeReplyTaxVendorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5787;
        public override uint MessageID { get { return ProtocolId; } }

        public long ObjectValue = 0;
        public long TotalTaxValue = 0;

        public ExchangeReplyTaxVendorMessage()
        {
        }

        public ExchangeReplyTaxVendorMessage(
            long objectValue,
            long totalTaxValue
        )
        {
            ObjectValue = objectValue;
            TotalTaxValue = totalTaxValue;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(ObjectValue);
            writer.WriteVarLong(TotalTaxValue);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectValue = reader.ReadVarLong();
            TotalTaxValue = reader.ReadVarLong();
        }
    }
}