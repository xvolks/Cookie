using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangePlayerRequestMessage : ExchangeRequestMessage
    {
        public new const uint ProtocolId = 5773;
        public override uint MessageID { get { return ProtocolId; } }

        public long Target = 0;

        public ExchangePlayerRequestMessage(): base()
        {
        }

        public ExchangePlayerRequestMessage(
            byte exchangeType,
            long target
        ): base(
            exchangeType
        )
        {
            Target = target;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Target);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Target = reader.ReadVarLong();
        }
    }
}