using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5599;
        public override uint MessageID { get { return ProtocolId; } }

        public FriendInformations FriendAdded;

        public FriendAddedMessage()
        {
        }

        public FriendAddedMessage(
            FriendInformations friendAdded
        )
        {
            FriendAdded = friendAdded;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(FriendAdded.TypeId);
            FriendAdded.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var friendAddedTypeId = reader.ReadShort();
            FriendAdded = new FriendInformations();
            FriendAdded.Deserialize(reader);
        }
    }
}