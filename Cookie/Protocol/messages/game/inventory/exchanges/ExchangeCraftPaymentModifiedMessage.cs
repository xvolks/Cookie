using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftPaymentModifiedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6578;
        public override uint MessageID { get { return ProtocolId; } }

        public long GoldSum = 0;

        public ExchangeCraftPaymentModifiedMessage()
        {
        }

        public ExchangeCraftPaymentModifiedMessage(
            long goldSum
        )
        {
            GoldSum = goldSum;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(GoldSum);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GoldSum = reader.ReadVarLong();
        }
    }
}