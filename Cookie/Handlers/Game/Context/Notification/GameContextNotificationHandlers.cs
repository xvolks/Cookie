using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Notification;

namespace Cookie.Handlers.Game.Context.Notification
{
    public class GameContextNotificationHandlers
    {
        [MessageHandler(NotificationListMessage.ProtocolId)]
        private void NotificationListMessageHandler(DofusClient Client, NotificationListMessage Message)
        {
            //
        }
    }
}
