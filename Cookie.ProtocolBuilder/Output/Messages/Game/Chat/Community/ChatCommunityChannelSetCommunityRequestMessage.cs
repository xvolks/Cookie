namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Community
{
    using Utils.IO;

    public class ChatCommunityChannelSetCommunityRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6729;
        public override ushort MessageID => ProtocolId;
        public short CommunityId { get; set; }

        public ChatCommunityChannelSetCommunityRequestMessage(short communityId)
        {
            CommunityId = communityId;
        }

        public ChatCommunityChannelSetCommunityRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CommunityId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CommunityId = reader.ReadShort();
        }

    }
}
