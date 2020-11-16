using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseSellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5697;

        public override ushort MessageID => ProtocolId;

        public int InstanceId { get; set; }
        public ulong Amount { get; set; }
        public bool ForSale { get; set; }
        public HouseSellRequestMessage() { }

        public HouseSellRequestMessage( int InstanceId, ulong Amount, bool ForSale ){
            this.InstanceId = InstanceId;
            this.Amount = Amount;
            this.ForSale = ForSale;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(InstanceId);
            writer.WriteVarUhLong(Amount);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(IDataReader reader)
        {
            InstanceId = reader.ReadInt();
            Amount = reader.ReadVarUhLong();
            ForSale = reader.ReadBoolean();
        }
    }
}
