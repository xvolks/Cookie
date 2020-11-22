using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5512;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ExchangeType = 0;

        public ExchangeStartedMessage()
        {
        }

        public ExchangeStartedMessage(
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