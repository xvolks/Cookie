using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseTeleportRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6726;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int HouseInstanceId = 0;

        public HouseTeleportRequestMessage()
        {
        }

        public HouseTeleportRequestMessage(
            int houseId,
            int houseInstanceId
        )
        {
            HouseId = houseId;
            HouseInstanceId = houseInstanceId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteInt(HouseInstanceId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            HouseInstanceId = reader.ReadInt();
        }
    }
}