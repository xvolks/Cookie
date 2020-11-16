using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5790;
        public override uint MessageID { get { return ProtocolId; } }

        public byte CraftResult = 0;

        public ExchangeCraftResultMessage()
        {
        }

        public ExchangeCraftResultMessage(
            byte craftResult
        )
        {
            CraftResult = craftResult;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(CraftResult);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CraftResult = reader.ReadByte();
        }
    }
}