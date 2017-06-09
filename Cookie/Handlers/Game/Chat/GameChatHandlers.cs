using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Chat;

namespace Cookie.Handlers.Game.Chat
{
    public class GameChatHandlers
    {
        [MessageHandler(ChatServerMessage.ProtocolId)]
        private void ChatServerMessageHandler(DofusClient Client, ChatServerMessage Message)
        {
            switch ((ChatChannelsMultiEnum)Message.Channel)
            {
                case ChatChannelsMultiEnum.CHANNEL_ADMIN:
                    Client.Logger.Log("[Admin] " + Message.SenderName + " : " + Message.Content, LogMessageType.Admin);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ALLIANCE:
                    Client.Logger.Log("[Alliance] " + Message.SenderName + " : " + Message.Content, LogMessageType.Alliance);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ARENA:
                    Client.Logger.Log("[Kolizéum] " + Message.SenderName + " : " + Message.Content, LogMessageType.Arena);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_COMMUNITY:
                    Client.Logger.Log("[Communauté] " + Message.SenderName + " : " + Message.Content, LogMessageType.Community);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                    Client.Logger.Log("[Général] " + Message.SenderName + " : " + Message.Content, LogMessageType.Global);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GUILD:
                    Client.Logger.Log("[Guilde] " + Message.SenderName + " : " + Message.Content, LogMessageType.Guild);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_NOOB:
                    Client.Logger.Log("[Débutant] " + Message.SenderName + " : " + Message.Content, LogMessageType.Noob);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_PARTY:
                    Client.Logger.Log("[Groupe] " + Message.SenderName + " : " + Message.Content, LogMessageType.Party);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SALES:
                    Client.Logger.Log("[Commerce] " + Message.SenderName + " : " + Message.Content, LogMessageType.Sales);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SEEK:
                    Client.Logger.Log("[Recrutement] " + Message.SenderName + " : " + Message.Content, LogMessageType.Seek);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_TEAM:
                    Client.Logger.Log("[Equipe] " + Message.SenderName + " : " + Message.Content);
                    break;
                default:
                    Client.Logger.Log(Message.SenderName + " : " + Message.Content, LogMessageType.Sender);
                    break;
            }
        }

        [MessageHandler(ChatErrorMessage.ProtocolId)]
        private void ChatErrorMessageHandler(DofusClient Client, ChatErrorMessage Message)
        {
            switch ((ChatErrorEnum)Message.Reason)
            {
                case ChatErrorEnum.CHAT_ERROR_NO_GUILD:
                    Client.Logger.Log("Vous ne possedez pas de guilde.", LogMessageType.Public);
                    break;
                default:
                    Client.Logger.Log("Erreur : " + (ChatErrorEnum)Message.Reason, LogMessageType.Public);
                    break;
            }
        }
    }
}
