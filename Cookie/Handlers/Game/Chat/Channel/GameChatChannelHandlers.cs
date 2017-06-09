using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Chat.Channel;

namespace Cookie.Handlers.Game.Chat.Channel
{
    public class GameChatChannelHandlers
    {
        [MessageHandler(EnabledChannelsMessage.ProtocolId)]
        private void EnabledChannelsMessageHandler(DofusClient Client, EnabledChannelsMessage Message)
        {
            //
        }

        [MessageHandler(ChannelEnablingChangeMessage.ProtocolId)]
        private void ChannelEnablingChangeMessageHandler(DofusClient Client, ChannelEnablingChangeMessage Message)
        {
            //
        }
    }
}
