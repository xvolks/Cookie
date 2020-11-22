using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PlayerStatusUpdateRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6387;
        public override uint MessageID { get { return ProtocolId; } }

        public PlayerStatus Status;

        public PlayerStatusUpdateRequestMessage()
        {
        }

        public PlayerStatusUpdateRequestMessage(
            PlayerStatus status
        )
        {
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}