using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
    {
        public new const uint ProtocolId = 5521;
        public override uint MessageID { get { return ProtocolId; } }

        public long Quantity = 0;

        public ExchangeKamaModifiedMessage(): base()
        {
        }

        public ExchangeKamaModifiedMessage(
            bool remote,
            long quantity
        ): base(
            remote
        )
        {
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarLong();
        }
    }
}