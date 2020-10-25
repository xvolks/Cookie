using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseBuyResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5735;
        public override uint MessageID { get { return ProtocolId; } }

        public bool SecondHand = false;
        public bool Bought = false;
        public int HouseId = 0;
        public int InstanceId = 0;
        public long RealPrice = 0;

        public HouseBuyResultMessage()
        {
        }

        public HouseBuyResultMessage(
            bool secondHand,
            bool bought,
            int houseId,
            int instanceId,
            long realPrice
        )
        {
            SecondHand = secondHand;
            Bought = bought;
            HouseId = houseId;
            InstanceId = instanceId;
            RealPrice = realPrice;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, SecondHand);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Bought);
            writer.WriteByte(box0);
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteVarLong(RealPrice);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            SecondHand = BooleanByteWrapper.GetFlag(box0, 1);
            Bought = BooleanByteWrapper.GetFlag(box0, 2);
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
            RealPrice = reader.ReadVarLong();
        }
    }
}