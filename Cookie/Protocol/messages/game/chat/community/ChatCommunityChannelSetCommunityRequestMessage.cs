using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatCommunityChannelSetCommunityRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6729;
        public override uint MessageID { get { return ProtocolId; } }

        public short CommunityId = 0;

        public ChatCommunityChannelSetCommunityRequestMessage()
        {
        }

        public ChatCommunityChannelSetCommunityRequestMessage(
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