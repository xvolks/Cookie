using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockSellRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5953;
        public override uint MessageID { get { return ProtocolId; } }

        public long Price = 0;
        public bool ForSale = false;

        public PaddockSellRequestMessage()
        {
        }

        public PaddockSellRequestMessage(
            long price,
            bool forSale
        )
        {
            Price = price;
            ForSale = forSale;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Price);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Price = reader.ReadVarLong();
            ForSale = reader.ReadBoolean();
        }
    }
}