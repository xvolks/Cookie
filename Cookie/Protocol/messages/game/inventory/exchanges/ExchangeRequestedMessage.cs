using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeRequestedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5522;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ExchangeType = 0;

        public ExchangeRequestedMessage()
        {
        }

        public ExchangeRequestedMessage(
            byte exchangeType
        )
        {
            ExchangeType = exchangeType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ExchangeType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ExchangeType = reader.ReadByte();
        }
    }
}