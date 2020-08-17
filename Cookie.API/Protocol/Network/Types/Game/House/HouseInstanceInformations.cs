using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.House
{
    public class HouseInstanceInformations : NetworkType
    {
        public const ushort ProtocolId = 511;

        public HouseInstanceInformations(bool secondHand, bool isLocked, bool isSaleLocked, int instanceId,
            string ownerName, long price)
        {
            SecondHand = secondHand;
            IsLocked = isLocked;
            IsSaleLocked = isSaleLocked;
            InstanceId = instanceId;
            OwnerName = ownerName;
            Price = price;
        }

        public HouseInstanceInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool SecondHand { get; set; }
        public bool IsLocked { get; set; }
        public bool IsSaleLocked { get; set; }
        public int InstanceId { get; set; }
        public string OwnerName { get; set; }
        public long Price { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, SecondHand);
            flag = BooleanByteWrapper.SetFlag(1, flag, IsLocked);
            flag = BooleanByteWrapper.SetFlag(2, flag, IsSaleLocked);
            writer.WriteByte(flag);
            writer.WriteInt(InstanceId);
            writer.WriteUTF(OwnerName);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            SecondHand = BooleanByteWrapper.GetFlag(flag, 0);
            IsLocked = BooleanByteWrapper.GetFlag(flag, 1);
            IsSaleLocked = BooleanByteWrapper.GetFlag(flag, 2);
            InstanceId = reader.ReadInt();
            OwnerName = reader.ReadUTF();
            Price = reader.ReadVarLong();
        }
    }
}