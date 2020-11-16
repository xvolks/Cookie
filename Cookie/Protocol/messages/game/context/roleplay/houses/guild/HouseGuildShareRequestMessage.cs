using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseGuildShareRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5704;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int InstanceId = 0;
        public bool Enable = false;
        public int Rights = 0;

        public HouseGuildShareRequestMessage()
        {
        }

        public HouseGuildShareRequestMessage(
            int houseId,
            int instanceId,
            bool enable,
            int rights
        )
        {
            HouseId = houseId;
            InstanceId = instanceId;
            Enable = enable;
            Rights = rights;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(Enable);
            writer.WriteVarInt(Rights);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
            Enable = reader.ReadBoolean();
            Rights = reader.ReadVarInt();
        }
    }
}