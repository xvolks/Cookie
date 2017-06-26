using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Queues;
using Cookie.API.Utils;
using Cookie.Core;

namespace Cookie.Handlers.Queues
{
    public class QueuesHandlers
    {
        [MessageHandler(LoginQueueStatusMessage.ProtocolId)]
        private void LoginQueueStatusMessageHandler(DofusClient client, LoginQueueStatusMessage message)
        {
            if (message.Position != 0 && message.Total != 0)
                Logger.Default.Log("Vous êtes en position " + message.Position + " sur " + message.Total +
                                   " dans la file d'attente.");
        }

        [MessageHandler(QueueStatusMessage.ProtocolId)]
        private void QueueStatusMessageHandler(DofusClient client, QueueStatusMessage message)
        {
            if (message.Position != 0 && message.Total != 0)
                Logger.Default.Log("Vous êtes en position " + message.Position + " sur " + message.Total +
                                   " dans la file d'attente.");
        }
    }
}