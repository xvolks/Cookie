using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HouseInstanceInformations : NetworkType
    {
        public const short ProtocolId = 511;
        public override short TypeId { get { return ProtocolId; } }

        public bool SecondHand = false;
        public bool IsLocked = false;
        public bool IsSaleLocked = false;
        public int InstanceId = 0;
        public string OwnerName;
        public long Price = 0;

        public HouseInstanceInformations()
        {
        }

        public HouseInstanceInformations(
            bool secondHand,
            bool isLocked,
            bool isSaleLocked,
            int instanceId,
            string ownerName,
            long price
        )
        {
            SecondHand = secondHand;
            IsLocked = isLocked;
            IsSaleLocked = isSaleLocked;
            InstanceId = instanceId;
            OwnerName = ownerName;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, SecondHand);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsLocked);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, IsSaleLocked);
            writer.WriteByte(box0);
            writer.WriteInt(InstanceId);
            writer.WriteUTF(OwnerName);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            SecondHand = BooleanByteWrapper.GetFlag(box0, 1);
            IsLocked = BooleanByteWrapper.GetFlag(box0, 2);
            IsSaleLocked = BooleanByteWrapper.GetFlag(box0, 3);
            InstanceId = reader.ReadInt();
            OwnerName = reader.ReadUTF();
            Price = reader.ReadVarLong();
        }
    }
}