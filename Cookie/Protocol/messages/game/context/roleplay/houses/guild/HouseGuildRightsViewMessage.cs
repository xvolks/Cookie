using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseGuildRightsViewMessage : NetworkMessage
    {
        public const uint ProtocolId = 5700;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int InstanceId = 0;

        public HouseGuildRightsViewMessage()
        {
        }

        public HouseGuildRightsViewMessage(
            int houseId,
            int instanceId
        )
        {
            HouseId = houseId;
            InstanceId = instanceId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
        }
    }
}