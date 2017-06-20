using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Chat.Smiley;

namespace Cookie.Handlers.Game.Chat.Smiley
{
    public class GameChatSmileyHandlers
    {

        [MessageHandler(ChatSmileyExtraPackListMessage.ProtocolId)]
        private void ChatSmileyExtraPackListMessageHandler(DofusClient Client, ChatSmileyExtraPackListMessage Message)
        {
        }
        [MessageHandler(ChatSmileyMessage.ProtocolId)]
        private void ChatSmileyMessageHandler(DofusClient Client, ChatSmileyMessage Message)
        {
        }
        [MessageHandler(ChatSmileyRequestMessage.ProtocolId)]
        private void ChatSmileyRequestMessageHandler(DofusClient Client, ChatSmileyRequestMessage Message)
        {
        }
        [MessageHandler(LocalizedChatSmileyMessage.ProtocolId)]
        private void LocalizedChatSmileyMessageHandler(DofusClient Client, LocalizedChatSmileyMessage Message)
        {
        }
        [MessageHandler(MoodSmileyRequestMessage.ProtocolId)]
        private void MoodSmileyRequestMessageHandler(DofusClient Client, MoodSmileyRequestMessage Message)
        {
        }
        [MessageHandler(MoodSmileyResultMessage.ProtocolId)]
        private void MoodSmileyResultMessageHandler(DofusClient Client, MoodSmileyResultMessage Message)
        {
        }
        [MessageHandler(MoodSmileyUpdateMessage.ProtocolId)]
        private void MoodSmileyUpdateMessageHandler(DofusClient Client, MoodSmileyUpdateMessage Message)
        {
        }
    }
}
