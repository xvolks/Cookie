using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseGuildNoneMessage : NetworkMessage
    {
        public const uint ProtocolId = 5701;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int InstanceId = 0;
        public bool SecondHand = false;

        public HouseGuildNoneMessage()
        {
        }

        public HouseGuildNoneMessage(
            int houseId,
            int instanceId,
            bool secondHand
        )
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
        }
    }
}