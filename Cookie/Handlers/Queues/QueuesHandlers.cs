using Cookie.Core;
using Cookie.Protocol.Network.Messages.Queues;

namespace Cookie.Handlers.Queues
{
    public class QueuesHandlers
    {
        [MessageHandler(LoginQueueStatusMessage.ProtocolId)]
        private void LoginQueueStatusMessageHandler(DofusClient Client, LoginQueueStatusMessage Message)
        {
            if (Message.Position != 0 && Message.Total != 0)
                Client.Logger.Log("Vous êtes en position " + Message.Position + " sur " + Message.Total + " dans la file d'attente.");
        }

        [MessageHandler(QueueStatusMessage.ProtocolId)]
        private void QueueStatusMessageHandler(DofusClient Client, QueueStatusMessage Message)
        {
            if (Message.Position != 0 && Message.Total != 0)
                Client.Logger.Log("Vous êtes en position " + Message.Position + " sur " + Message.Total + " dans la file d'attente.");
        }
    }
}
