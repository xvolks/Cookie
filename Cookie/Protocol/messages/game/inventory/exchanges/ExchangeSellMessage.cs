using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeSellMessage : NetworkMessage
    {
        public const uint ProtocolId = 5778;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectToSellId = 0;
        public int Quantity = 0;

        public ExchangeSellMessage()
        {
        }

        public ExchangeSellMessage(
            int objectToSellId,
            int quantity
        )
        {
            ObjectToSellId = objectToSellId;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectToSellId);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectToSellId = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}