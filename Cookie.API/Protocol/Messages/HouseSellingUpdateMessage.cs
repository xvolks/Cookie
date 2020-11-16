using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseSellingUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6727;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public ulong RealPrice { get; set; }
        public string BuyerName { get; set; }
        public HouseSellingUpdateMessage() { }

        public HouseSellingUpdateMessage( uint HouseId, int InstanceId, bool SecondHand, ulong RealPrice, string BuyerName ){
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
            this.SecondHand = SecondHand;
            this.RealPrice = RealPrice;
            this.BuyerName = BuyerName;
        }

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
