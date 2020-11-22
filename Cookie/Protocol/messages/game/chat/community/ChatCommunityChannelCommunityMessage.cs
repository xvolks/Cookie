using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatCommunityChannelCommunityMessage : NetworkMessage
    {
        public const uint ProtocolId = 6730;
        public override uint MessageID { get { return ProtocolId; } }

        public short CommunityId = 0;

        public ChatCommunityChannelCommunityMessage()
        {
        }

        public ChatCommunityChannelCommunityMessage(
            short communityId
        )
        {
            CommunityId = communityId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(CommunityId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CommunityId = reader.ReadShort();
        }
    }
}