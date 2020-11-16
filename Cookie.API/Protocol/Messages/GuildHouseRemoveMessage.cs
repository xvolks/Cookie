using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildHouseRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6180;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public GuildHouseRemoveMessage() { }

        public GuildHouseRemoveMessage( uint HouseId, int InstanceId, bool SecondHand ){
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
            this.SecondHand = SecondHand;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
        }
    }
}
