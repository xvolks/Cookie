using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendSpouseJoinRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5604;
        public override uint MessageID { get { return ProtocolId; } }

        public FriendSpouseJoinRequestMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}