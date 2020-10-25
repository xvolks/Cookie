using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PurchasableDialogMessage : NetworkMessage
    {
        public const uint ProtocolId = 5739;
        public override uint MessageID { get { return ProtocolId; } }

        public bool BuyOrSell = false;
        public bool SecondHand = false;
        public double PurchasableId = 0;
        public int PurchasableInstanceId = 0;
        public long Price = 0;

        public PurchasableDialogMessage()
        {
        }

        public PurchasableDialogMessage(
            bool buyOrSell,
            bool secondHand,
            double purchasableId,
            int purchasableInstanceId,
            long price
        )
        {
            BuyOrSell = buyOrSell;
            SecondHand = secondHand;
            PurchasableId = purchasableId;
            PurchasableInstanceId = purchasableInstanceId;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, BuyOrSell);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, SecondHand);
            writer.WriteByte(box0);
            writer.WriteDouble(PurchasableId);
            writer.WriteInt(PurchasableInstanceId);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            BuyOrSell = BooleanByteWrapper.GetFlag(box0, 1);
            SecondHand = BooleanByteWrapper.GetFlag(box0, 2);
            PurchasableId = reader.ReadDouble();
            PurchasableInstanceId = reader.ReadInt();
            Price = reader.ReadVarLong();
        }
    }
}