using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectMoveKamaMessage : NetworkMessage
    {
        public const uint ProtocolId = 5520;
        public override uint MessageID { get { return ProtocolId; } }

        public long Quantity = 0;

        public ExchangeObjectMoveKamaMessage()
        {
        }

        public ExchangeObjectMoveKamaMessage(
            long quantity
        )
        {
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Quantity = reader.ReadVarLong();
        }
    }
}