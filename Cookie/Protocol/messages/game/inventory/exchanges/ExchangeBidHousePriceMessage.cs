using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHousePriceMessage : NetworkMessage
    {
        public const uint ProtocolId = 5805;
        public override uint MessageID { get { return ProtocolId; } }

        public short GenId = 0;

        public ExchangeBidHousePriceMessage()
        {
        }

        public ExchangeBidHousePriceMessage(
            short genId
        )
        {
            GenId = genId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(GenId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GenId = reader.ReadVarShort();
        }
    }
}