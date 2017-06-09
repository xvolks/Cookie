using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Chat.Community;

namespace Cookie.Handlers.Game.Chat.Community
{
    public class GameChatCommunityHandlers
    {
        [MessageHandler(ChatCommunityChannelCommunityMessage.ProtocolId)]
        private void ChatCommunityChannelCommunityMessageHandler(DofusClient Client, ChatCommunityChannelCommunityMessage Message)
        {
            //
        }
    }
}
