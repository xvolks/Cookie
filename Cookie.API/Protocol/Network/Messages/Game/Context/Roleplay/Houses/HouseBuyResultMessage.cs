using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseBuyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5735;

        public HouseBuyResultMessage(bool secondHand, bool bought, uint houseId, int instanceId, ulong realPrice)
        {
            SecondHand = secondHand;
            Bought = bought;
            HouseId = houseId;
            InstanceId = instanceId;
            RealPrice = realPrice;
        }

        public HouseBuyResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool SecondHand { get; set; }
        public bool Bought { get; set; }
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public ulong RealPrice { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, SecondHand);
            flag = BooleanByteWrapper.SetFlag(1, flag, Bought);
            writer.WriteByte(flag);
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteVarUhLong(RealPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            SecondHand = BooleanByteWrapper.GetFlag(flag, 0);
            Bought = BooleanByteWrapper.GetFlag(flag, 1);
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            RealPrice = reader.ReadVarUhLong();
        }
    }
}