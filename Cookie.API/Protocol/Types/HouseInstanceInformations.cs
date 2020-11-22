using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseInstanceInformations : NetworkType
    {
        public const ushort ProtocolId = 511;

        public override ushort TypeID => ProtocolId;

        public bool SecondHand { get; set; }
        public bool IsLocked { get; set; }
        public bool IsSaleLocked { get; set; }
        public int InstanceId { get; set; }
        public string OwnerName { get; set; }
        public long Price { get; set; }
        public HouseInstanceInformations() { }

        public HouseInstanceInformations( bool SecondHand, bool IsLocked, bool IsSaleLocked, int InstanceId, string OwnerName, long Price ){
            this.SecondHand = SecondHand;
            this.IsLocked = IsLocked;
            this.IsSaleLocked = IsSaleLocked;
            this.InstanceId = InstanceId;
            this.OwnerName = OwnerName;
            this.Price = Price;
        }

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
