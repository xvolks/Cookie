using Cookie.Core;
using Cookie.Protocol.Network.Messages.Web.Ankabox;

namespace Cookie.Handlers.Web.Ankabox
{
    public class WebAnkaboxHandlers
    {
        [MessageHandler(MailStatusMessage.ProtocolId)]
        private void MailStatusMessageHandler(DofusClient Client, MailStatusMessage Message)
        {
            if (Message.Total > 0)
                Client.Logger.Log($"Ankabox: Vous avez {Message.Unread} message(s) non-lus sur {Message.Total} dans votre ankabox.", LogMessageType.Default);
        }

        [MessageHandler(NewMailMessage.ProtocolId)]
        private void NewMailMessageHandler(DofusClient Client, NewMailMessage Message)
        {
            Client.Logger.Log($"Ankabox: Vous avez reçu un nouveau message de la part de : {Message.SendersAccountId}", LogMessageType.Default);
            if (Message.Total > 0)
                Client.Logger.Log($"Ankabox: Vous avez {Message.Unread} message(s) non-lus sur {Message.Total} dans votre ankabox.", LogMessageType.Default);
        }
    }
}
