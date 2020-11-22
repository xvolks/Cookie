using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
    {
        public new const uint ProtocolId = 5514;
        public override uint MessageID { get { return ProtocolId; } }

        public long Price = 0;

        public ExchangeObjectMovePricedMessage(): base()
        {
        }

        public ExchangeObjectMovePricedMessage(
            int objectUID,
            int quantity,
            long price
        ): base(
            objectUID,
            quantity
        )
        {
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Price = reader.ReadVarLong();
        }
    }
}