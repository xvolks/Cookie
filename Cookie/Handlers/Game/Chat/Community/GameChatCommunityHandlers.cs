using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Chat.Community;

namespace Cookie.Handlers.Game.Chat.Community
{
    public class GameChatCommunityHandlers
    {
        [MessageHandler(ChatCommunityChannelCommunityMessage.ProtocolId)]
        private void ChatCommunityChannelCommunityMessageHandler(DofusClient client,
            ChatCommunityChannelCommunityMessage message)
        {
            //
        }
    }
}