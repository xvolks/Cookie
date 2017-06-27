using Cookie.API.Core;
using Cookie.API.Game.Chat;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Chat;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Chat
{
    public class Chat : IChat
    {
        public Chat(IAccount account)
        {
            account.Network.RegisterPacket<ChatServerMessage>(HandleChatServerMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ChatErrorMessage>(HandleChatErrorMessage, MessagePriority.VeryHigh);
        }

        private void HandleChatServerMessage(IAccount account, ChatServerMessage message)
        {
            switch ((ChatChannelsMultiEnum) message.Channel)
            {
                case ChatChannelsMultiEnum.CHANNEL_ADMIN:
                    Logger.Default.Log("(Admin) " + message.SenderName + " : " + message.Content, LogMessageType.Admin);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ALLIANCE:
                    Logger.Default.Log("(Alliance) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Alliance);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ARENA:
                    Logger.Default.Log("(Kolizéum) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Arena);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_COMMUNITY:
                    Logger.Default.Log("(Communauté) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Community);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                    Logger.Default.Log("(Général) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Global);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GUILD:
                    Logger.Default.Log("(Guilde) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Guild);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_NOOB:
                    Logger.Default.Log("(Débutant) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Noob);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_PARTY:
                    Logger.Default.Log("(Groupe) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Party);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SALES:
                    Logger.Default.Log("(Commerce) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Sales);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SEEK:
                    Logger.Default.Log("(Recrutement) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Seek);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_TEAM:
                    Logger.Default.Log("(Equipe) " + message.SenderName + " : " + message.Content);
                    break;
                default:
                    Logger.Default.Log(message.SenderName + " : " + message.Content, LogMessageType.Sender);
                    break;
            }
        }

        private void HandleChatErrorMessage(IAccount account, ChatErrorMessage message)
        {
            switch ((ChatErrorEnum) message.Reason)
            {
                case ChatErrorEnum.CHAT_ERROR_NO_GUILD:
                    Logger.Default.Log("Vous ne possedez pas de guilde.", LogMessageType.Public);
                    break;
                default:
                    Logger.Default.Log("Erreur : " + (ChatErrorEnum) message.Reason, LogMessageType.Public);
                    break;
            }
        }
    }
}