using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Context.Notification;

namespace Cookie.Handlers.Game.Context.Notification
{
    public class GameContextNotificationHandlers
    {
        [MessageHandler(NotificationListMessage.ProtocolId)]
        private void NotificationListMessageHandler(DofusClient client, NotificationListMessage message)
        {
            //
        }
    }
}