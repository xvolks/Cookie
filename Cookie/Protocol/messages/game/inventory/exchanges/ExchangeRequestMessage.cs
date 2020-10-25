using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5505;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ExchangeType = 0;

        public ExchangeRequestMessage()
        {
        }

        public ExchangeRequestMessage(
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