using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockSellBuyDialogMessage : NetworkMessage
    {
        public const uint ProtocolId = 6018;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Bsell = false;
        public int OwnerId = 0;
        public long Price = 0;

        public PaddockSellBuyDialogMessage()
        {
        }

        public PaddockSellBuyDialogMessage(
            bool bsell,
            int ownerId,
            long price
        )
        {
            Bsell = bsell;
            OwnerId = ownerId;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Bsell);
            writer.WriteVarInt(OwnerId);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Bsell = reader.ReadBoolean();
            OwnerId = reader.ReadVarInt();
            Price = reader.ReadVarLong();
        }
    }
}