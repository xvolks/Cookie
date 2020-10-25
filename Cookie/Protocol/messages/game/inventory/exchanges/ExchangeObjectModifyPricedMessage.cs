using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
    {
        public new const uint ProtocolId = 6238;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeObjectModifyPricedMessage(): base()
        {
        }

        public ExchangeObjectModifyPricedMessage(
            int objectUID,
            int quantity,
            long price
        ): base(
            objectUID,
            quantity,
            price
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}