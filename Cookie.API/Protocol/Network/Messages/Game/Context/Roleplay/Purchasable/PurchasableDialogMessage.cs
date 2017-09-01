using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Purchasable
{
    public class PurchasableDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5739;

        public PurchasableDialogMessage(bool buyOrSell, bool secondHand, uint purchasableId, int purchasableInstanceId,
            ulong price)
        {
            BuyOrSell = buyOrSell;
            SecondHand = secondHand;
            PurchasableId = purchasableId;
            PurchasableInstanceId = purchasableInstanceId;
            Price = price;
        }

        public PurchasableDialogMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool BuyOrSell { get; set; }
        public bool SecondHand { get; set; }
        public uint PurchasableId { get; set; }
        public int PurchasableInstanceId { get; set; }
        public ulong Price { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, BuyOrSell);
            flag = BooleanByteWrapper.SetFlag(1, flag, SecondHand);
            writer.WriteByte(flag);
            writer.WriteVarUhInt(PurchasableId);
            writer.WriteInt(PurchasableInstanceId);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            BuyOrSell = BooleanByteWrapper.GetFlag(flag, 0);
            SecondHand = BooleanByteWrapper.GetFlag(flag, 1);
            PurchasableId = reader.ReadVarUhInt();
            PurchasableInstanceId = reader.ReadInt();
            Price = reader.ReadVarUhLong();
        }
    }
}