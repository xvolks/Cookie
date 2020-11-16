using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendDeleteRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5603;
        public override uint MessageID { get { return ProtocolId; } }

        public int AccountId = 0;

        public FriendDeleteRequestMessage()
        {
        }

        public FriendDeleteRequestMessage(
            int accountId
        )
        {
            AccountId = accountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AccountId = reader.ReadInt();
        }
    }
}