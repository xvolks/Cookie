using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseSellingUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6727;

        public HouseSellingUpdateMessage(uint houseId, int instanceId, bool secondHand, ulong realPrice,
            string buyerName)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
            RealPrice = realPrice;
            BuyerName = buyerName;
        }

        public HouseSellingUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public ulong RealPrice { get; set; }
        public string BuyerName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteVarUhLong(RealPrice);
            writer.WriteUTF(BuyerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            RealPrice = reader.ReadVarUhLong();
            BuyerName = reader.ReadUTF();
        }
    }
}