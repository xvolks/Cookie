using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseTeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6726;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int HouseInstanceId { get; set; }
        public HouseTeleportRequestMessage() { }

        public HouseTeleportRequestMessage( uint HouseId, int HouseInstanceId ){
            this.HouseId = HouseId;
            this.HouseInstanceId = HouseInstanceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(HouseInstanceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            HouseInstanceId = reader.ReadInt();
        }
    }
}
