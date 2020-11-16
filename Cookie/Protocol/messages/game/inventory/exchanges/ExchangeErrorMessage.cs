using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5513;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ErrorType = 0;

        public ExchangeErrorMessage()
        {
        }

        public ExchangeErrorMessage(
            byte errorType
        )
        {
            ErrorType = errorType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ErrorType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ErrorType = reader.ReadByte();
        }
    }
}