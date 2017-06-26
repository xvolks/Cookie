using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Server.Basic;
using Cookie.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Server.Basic
{
    public class ServerBasicHandlers
    {
        [MessageHandler(SystemMessageDisplayMessage.ProtocolId)]
        private void SystemMessageDisplayMessageHandler(DofusClient client, SystemMessageDisplayMessage message)
        {
            if (message.MsgId == 13)
            {
                Logger.Default.Log(
                    "Le serveur est actuellement en maintenance. Vous pouvez consulter la rubrique Etats des serveurs du forum officiel, ou sur le site du Support pour plus d'informations. Merci de votre compréhension.",
                    LogMessageType.Public);
                client.Socket.Close();
            }
        }
    }
}