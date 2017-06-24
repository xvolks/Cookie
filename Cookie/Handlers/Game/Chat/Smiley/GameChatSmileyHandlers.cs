using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley;

namespace Cookie.Handlers.Game.Chat.Smiley
{
    public class GameChatSmileyHandlers
    {
        [MessageHandler(ChatSmileyExtraPackListMessage.ProtocolId)]
        private void ChatSmileyExtraPackListMessageHandler(DofusClient client, ChatSmileyExtraPackListMessage message)
        {
        }

        [MessageHandler(ChatSmileyMessage.ProtocolId)]
        private void ChatSmileyMessageHandler(DofusClient client, ChatSmileyMessage message)
        {
        }

        [MessageHandler(ChatSmileyRequestMessage.ProtocolId)]
        private void ChatSmileyRequestMessageHandler(DofusClient client, ChatSmileyRequestMessage message)
        {
        }

        [MessageHandler(LocalizedChatSmileyMessage.ProtocolId)]
        private void LocalizedChatSmileyMessageHandler(DofusClient client, LocalizedChatSmileyMessage message)
        {
        }

        [MessageHandler(MoodSmileyRequestMessage.ProtocolId)]
        private void MoodSmileyRequestMessageHandler(DofusClient client, MoodSmileyRequestMessage message)
        {
        }

        [MessageHandler(MoodSmileyResultMessage.ProtocolId)]
        private void MoodSmileyResultMessageHandler(DofusClient client, MoodSmileyResultMessage message)
        {
        }

        [MessageHandler(MoodSmileyUpdateMessage.ProtocolId)]
        private void MoodSmileyUpdateMessageHandler(DofusClient client, MoodSmileyUpdateMessage message)
        {
        }
    }
}