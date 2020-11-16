using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMoneyMovementInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6834;
        public override uint MessageID { get { return ProtocolId; } }

        public long Limit = 0;

        public ExchangeMoneyMovementInformationMessage()
        {
        }

        public ExchangeMoneyMovementInformationMessage(
            long limit
        )
        {
            Limit = limit;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Limit);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Limit = reader.ReadVarLong();
        }
    }
}