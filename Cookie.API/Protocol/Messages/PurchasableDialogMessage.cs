using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PurchasableDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5739;

        public override ushort MessageID => ProtocolId;

        public bool BuyOrSell { get; set; }
        public bool SecondHand { get; set; }
        public double PurchasableId { get; set; }
        public int PurchasableInstanceId { get; set; }
        public ulong Price { get; set; }
        public PurchasableDialogMessage() { }

        public PurchasableDialogMessage( bool BuyOrSell, bool SecondHand, double PurchasableId, int PurchasableInstanceId, ulong Price ){
            this.BuyOrSell = BuyOrSell;
            this.SecondHand = SecondHand;
            this.PurchasableId = PurchasableId;
            this.PurchasableInstanceId = PurchasableInstanceId;
            this.Price = Price;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, BuyOrSell);
			flag = BooleanByteWrapper.SetFlag(1, flag, SecondHand);
			writer.WriteByte(flag);
            writer.WriteDouble(PurchasableId);
            writer.WriteInt(PurchasableInstanceId);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			BuyOrSell = BooleanByteWrapper.GetFlag(flag, 0);;
			SecondHand = BooleanByteWrapper.GetFlag(flag, 1);;
            PurchasableId = reader.ReadDouble();
            PurchasableInstanceId = reader.ReadInt();
            Price = reader.ReadVarUhLong();
        }
    }
}
