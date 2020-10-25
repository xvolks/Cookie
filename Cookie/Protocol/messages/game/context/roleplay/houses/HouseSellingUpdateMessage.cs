using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseSellingUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6727;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int InstanceId = 0;
        public bool SecondHand = false;
        public long RealPrice = 0;
        public string BuyerName;

        public HouseSellingUpdateMessage()
        {
        }

        public HouseSellingUpdateMessage(
            int houseId,
            int instanceId,
            bool secondHand,
            long realPrice,
            string buyerName
        )
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
            RealPrice = realPrice;
            BuyerName = buyerName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteVarLong(RealPrice);
            writer.WriteUTF(BuyerName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            RealPrice = reader.ReadVarLong();
            BuyerName = reader.ReadUTF();
        }
    }
}