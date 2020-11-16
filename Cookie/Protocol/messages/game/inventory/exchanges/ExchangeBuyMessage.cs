using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBuyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5774;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectToBuyId = 0;
        public int Quantity = 0;

        public ExchangeBuyMessage()
        {
        }

        public ExchangeBuyMessage(
            int objectToBuyId,
            int quantity
        )
        {
            ObjectToBuyId = objectToBuyId;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectToBuyId);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectToBuyId = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}