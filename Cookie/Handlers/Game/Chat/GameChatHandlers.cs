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
                    Client.Logger.Log("(Admin) " + Message.SenderName + " : " + Message.Content, LogMessageType.Admin);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ALLIANCE:
                    Client.Logger.Log("(Alliance) " + Message.SenderName + " : " + Message.Content, LogMessageType.Alliance);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ARENA:
                    Client.Logger.Log("(Kolizéum) " + Message.SenderName + " : " + Message.Content, LogMessageType.Arena);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_COMMUNITY:
                    Client.Logger.Log("(Communauté) " + Message.SenderName + " : " + Message.Content, LogMessageType.Community);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                    Client.Logger.Log("(Général) " + Message.SenderName + " : " + Message.Content, LogMessageType.Global);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GUILD:
                    Client.Logger.Log("(Guilde) " + Message.SenderName + " : " + Message.Content, LogMessageType.Guild);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_NOOB:
                    Client.Logger.Log("(Débutant) " + Message.SenderName + " : " + Message.Content, LogMessageType.Noob);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_PARTY:
                    Client.Logger.Log("(Groupe) " + Message.SenderName + " : " + Message.Content, LogMessageType.Party);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SALES:
                    Client.Logger.Log("(Commerce) " + Message.SenderName + " : " + Message.Content, LogMessageType.Sales);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SEEK:
                    Client.Logger.Log("(Recrutement) " + Message.SenderName + " : " + Message.Content, LogMessageType.Seek);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_TEAM:
                    Client.Logger.Log("(Equipe) " + Message.SenderName + " : " + Message.Content);
                    break;
                default:
                    Client.Logger.Log(Message.SenderName + " : " + Message.Content, LogMessageType.Sender);
                    break;
            }
        }

        [MessageHandler(ChatServerWithObjectMessage.ProtocolId)]
        private void ChatServerWithObjectMessageHandler(DofusClient Client, ChatServerWithObjectMessage Message)
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
        private void ChatAbstractClientMessageHandler(DofusClient Client, ChatAbstractClientMessage Message)
        {
            //
        }
        [MessageHandler(ChatAbstractServerMessage.ProtocolId)]
        private void ChatAbstractServerMessageHandler(DofusClient Client, ChatAbstractServerMessage Message)
        {
            //
        }
        [MessageHandler(ChatAdminServerMessage.ProtocolId)]
        private void ChatAdminServerMessageHandler(DofusClient Client, ChatAdminServerMessage Message)
        {
            //
        }
        [MessageHandler(ChatClientMultiMessage.ProtocolId)]
        private void ChatClientMultiMessageHandler(DofusClient Client, ChatClientMultiMessage Message)
        {
            //
        }
        [MessageHandler(ChatClientMultiWithObjectMessage.ProtocolId)]
        private void ChatClientMultiWithObjectMessageHandler(DofusClient Client, ChatClientMultiWithObjectMessage Message)
        {
            //
        }
        [MessageHandler(ChatClientPrivateMessage.ProtocolId)]
        private void ChatClientPrivateMessageHandler(DofusClient Client, ChatClientPrivateMessage Message)
        {
            //
        }
        [MessageHandler(ChatClientPrivateWithObjectMessage.ProtocolId)]
        private void ChatClientPrivateWithObjectMessageHandler(DofusClient Client, ChatClientPrivateWithObjectMessage Message)
        {
            //
        }
        [MessageHandler(ChatServerCopyMessage.ProtocolId)]
        private void ChatServerCopyMessageHandler(DofusClient Client, ChatServerCopyMessage Message)
        {
            //
        }
        [MessageHandler(ChatServerCopyWithObjectMessage.ProtocolId)]
        private void ChatServerCopyWithObjectMessageHandler(DofusClient Client, ChatServerCopyWithObjectMessage Message)
        {
            //
        }
    }
}
