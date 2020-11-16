using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendSpouseFollowWithCompassRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5606;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Enable = false;

        public FriendSpouseFollowWithCompassRequestMessage()
        {
        }

        public FriendSpouseFollowWithCompassRequestMessage(
            bool enable
        )
        {
            Enable = enable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}