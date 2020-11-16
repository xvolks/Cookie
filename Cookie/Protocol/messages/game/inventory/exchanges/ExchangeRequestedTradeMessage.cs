using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
    {
        public new const uint ProtocolId = 5523;
        public override uint MessageID { get { return ProtocolId; } }

        public long Source = 0;
        public long Target = 0;

        public ExchangeRequestedTradeMessage(): base()
        {
        }

        public ExchangeRequestedTradeMessage(
            byte exchangeType,
            long source,
            long target
        ): base(
            exchangeType
        )
        {
            Source = source;
            Target = target;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Source);
            writer.WriteVarLong(Target);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Source = reader.ReadVarLong();
            Target = reader.ReadVarLong();
        }
    }
}