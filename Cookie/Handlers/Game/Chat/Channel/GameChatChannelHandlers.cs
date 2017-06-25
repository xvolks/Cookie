using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Chat.Channel;
using Cookie.Core;

namespace Cookie.Handlers.Game.Chat.Channel
{
    public class GameChatChannelHandlers
    {
        [MessageHandler(EnabledChannelsMessage.ProtocolId)]
        private void EnabledChannelsMessageHandler(DofusClient client, EnabledChannelsMessage message)
        {
            //
        }

        [MessageHandler(ChannelEnablingChangeMessage.ProtocolId)]
        private void ChannelEnablingChangeMessageHandler(DofusClient client, ChannelEnablingChangeMessage message)
        {
            //
        }
    }
}