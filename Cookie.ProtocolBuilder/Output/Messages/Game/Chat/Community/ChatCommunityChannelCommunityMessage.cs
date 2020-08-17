namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Community
{
    using Utils.IO;

    public class ChatCommunityChannelCommunityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6730;
        public override ushort MessageID => ProtocolId;
        public short CommunityId { get; set; }

        public ChatCommunityChannelCommunityMessage(short communityId)
        {
            CommunityId = communityId;
        }

        public ChatCommunityChannelCommunityMessage() { }

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
