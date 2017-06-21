using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Chat;

namespace Cookie.Handlers.Game.Chat
{
    public class GameChatHandlers
    {
        [MessageHandler(ChatServerMessage.ProtocolId)]
        private void ChatServerMessageHandler(DofusClient client, ChatServerMessage message)
        {
            switch ((ChatChannelsMultiEnum)message.Channel)
            {
                case ChatChannelsMultiEnum.CHANNEL_ADMIN:
                    client.Logger.Log("(Admin) " + message.SenderName + " : " + message.Content, LogMessageType.Admin);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ALLIANCE:
                    client.Logger.Log("(Alliance) " + message.SenderName + " : " + message.Content, LogMessageType.Alliance);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ARENA:
                    client.Logger.Log("(Kolizéum) " + message.SenderName + " : " + message.Content, LogMessageType.Arena);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_COMMUNITY:
                    client.Logger.Log("(Communauté) " + message.SenderName + " : " + message.Content, LogMessageType.Community);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                    client.Logger.Log("(Général) " + message.SenderName + " : " + message.Content, LogMessageType.Global);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GUILD:
                    client.Logger.Log("(Guilde) " + message.SenderName + " : " + message.Content, LogMessageType.Guild);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_NOOB:
                    client.Logger.Log("(Débutant) " + message.SenderName + " : " + message.Content, LogMessageType.Noob);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_PARTY:
                    client.Logger.Log("(Groupe) " + message.SenderName + " : " + message.Content, LogMessageType.Party);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SALES:
                    client.Logger.Log("(Commerce) " + message.SenderName + " : " + message.Content, LogMessageType.Sales);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SEEK:
                    client.Logger.Log("(Recrutement) " + message.SenderName + " : " + message.Content, LogMessageType.Seek);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_TEAM:
                    client.Logger.Log("(Equipe) " + message.SenderName + " : " + message.Content);
                    break;
                default:
                    client.Logger.Log(message.SenderName + " : " + message.Content, LogMessageType.Sender);
                    break;
            }
        }

        [MessageHandler(ChatServerWithObjectMessage.ProtocolId)]
        private void ChatServerWithObjectMessageHandler(DofusClient client, ChatServerWithObjectMessage message)
        {
            //
        }

        [MessageHandler(ChatErrorMessage.ProtocolId)]
        private void ChatErrorMessageHandler(DofusClient client, ChatErrorMessage message)
        {
            switch ((ChatErrorEnum)message.Reason)
            {
                case ChatErrorEnum.CHAT_ERROR_NO_GUILD:
                    client.Logger.Log("Vous ne possedez pas de guilde.", LogMessageType.Public);
                    break;
                case ChatErrorEnum.CHAT_ERROR_UNKNOWN:
                case ChatErrorEnum.CHAT_ERROR_RECEIVER_NOT_FOUND:
                case ChatErrorEnum.CHAT_ERROR_INTERIOR_MONOLOGUE:
                case ChatErrorEnum.CHAT_ERROR_NO_PARTY:
                case ChatErrorEnum.CHAT_ERROR_ALLIANCE:
                case ChatErrorEnum.CHAT_ERROR_INVALID_MAP:
                case ChatErrorEnum.CHAT_ERROR_NO_PARTY_ARENA:
                case ChatErrorEnum.CHAT_ERROR_NO_TEAM:
                case ChatErrorEnum.CHAT_ERROR_MALFORMED_CONTENT:
                default:
                    client.Logger.Log("Erreur : " + (ChatErrorEnum)message.Reason, LogMessageType.Public);
                    break;
            }
        }
        [MessageHandler(ChatAbstractClientMessage.ProtocolId)]
        private void ChatAbstractClientMessageHandler(DofusClient client, ChatAbstractClientMessage message)
        {
            //
        }
        [MessageHandler(ChatAbstractServerMessage.ProtocolId)]
        private void ChatAbstractServerMessageHandler(DofusClient client, ChatAbstractServerMessage message)
        {
            //
        }
        [MessageHandler(ChatAdminServerMessage.ProtocolId)]
        private void ChatAdminServerMessageHandler(DofusClient client, ChatAdminServerMessage message)
        {
            //
        }
        [MessageHandler(ChatClientMultiMessage.ProtocolId)]
        private void ChatClientMultiMessageHandler(DofusClient client, ChatClientMultiMessage message)
        {
            //
        }
        [MessageHandler(ChatClientMultiWithObjectMessage.ProtocolId)]
        private void ChatClientMultiWithObjectMessageHandler(DofusClient client, ChatClientMultiWithObjectMessage message)
        {
            //
        }
        [MessageHandler(ChatClientPrivateMessage.ProtocolId)]
        private void ChatClientPrivateMessageHandler(DofusClient client, ChatClientPrivateMessage message)
        {
            //
        }
        [MessageHandler(ChatClientPrivateWithObjectMessage.ProtocolId)]
        private void ChatClientPrivateWithObjectMessageHandler(DofusClient client, ChatClientPrivateWithObjectMessage message)
        {
            //
        }
        [MessageHandler(ChatServerCopyMessage.ProtocolId)]
        private void ChatServerCopyMessageHandler(DofusClient client, ChatServerCopyMessage message)
        {
            //
        }
        [MessageHandler(ChatServerCopyWithObjectMessage.ProtocolId)]
        private void ChatServerCopyWithObjectMessageHandler(DofusClient client, ChatServerCopyWithObjectMessage message)
        {
            //
        }
    }
}
