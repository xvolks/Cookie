using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Server.Basic
{
    public class ServerBasicHandlers
    {
        [MessageHandler(SystemMessageDisplayMessage.ProtocolId)]
        private void SystemMessageDisplayMessageHandler(DofusClient Client, SystemMessageDisplayMessage Message)
        {
            if (Message.MsgId == 13)
            {
                Client.Logger.Log("Le serveur est actuellement en maintenance. Vous pouvez consulter la rubrique Etats des serveurs du forum officiel, ou sur le site du Support pour plus d'informations. Merci de votre compréhension.", LogMessageType.Public);
                //Client.Disconnect();
            }
        }
    }
}
