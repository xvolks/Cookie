using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseBuyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5735;

        public override ushort MessageID => ProtocolId;

        public bool SecondHand { get; set; }
        public bool Bought { get; set; }
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public ulong RealPrice { get; set; }
        public HouseBuyResultMessage() { }

        public HouseBuyResultMessage( bool SecondHand, bool Bought, uint HouseId, int InstanceId, ulong RealPrice ){
            this.SecondHand = SecondHand;
            this.Bought = Bought;
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
            this.RealPrice = RealPrice;
        }

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
			SecondHand = BooleanByteWrapper.GetFlag(flag, 0);;
			Bought = BooleanByteWrapper.GetFlag(flag, 1);;
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            RealPrice = reader.ReadVarUhLong();
        }
    }
}
