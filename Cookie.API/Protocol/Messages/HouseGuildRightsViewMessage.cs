using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseGuildRightsViewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5700;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public HouseGuildRightsViewMessage() { }

        public HouseGuildRightsViewMessage( uint HouseId, int InstanceId ){
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
        }
    }
}
