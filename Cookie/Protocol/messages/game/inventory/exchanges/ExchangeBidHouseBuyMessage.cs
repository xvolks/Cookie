using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseBuyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5804;
        public override uint MessageID { get { return ProtocolId; } }

        public int Uid = 0;
        public int Qty = 0;
        public long Price = 0;

        public ExchangeBidHouseBuyMessage()
        {
        }

        public ExchangeBidHouseBuyMessage(
            int uid,
            int qty,
            long price
        )
        {
            Uid = uid;
            Qty = qty;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Uid);
            writer.WriteVarInt(Qty);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Uid = reader.ReadVarInt();
            Qty = reader.ReadVarInt();
            Price = reader.ReadVarLong();
        }
    }
}