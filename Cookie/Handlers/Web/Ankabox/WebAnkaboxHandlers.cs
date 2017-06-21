using Cookie.Core;
using Cookie.Protocol.Network.Messages.Web.Ankabox;

namespace Cookie.Handlers.Web.Ankabox
{
    public class WebAnkaboxHandlers
    {
        [MessageHandler(MailStatusMessage.ProtocolId)]
        private void MailStatusMessageHandler(DofusClient client, MailStatusMessage message)
        {
            if (message.Total > 0)
                client.Logger.Log(
                    $"Ankabox: Vous avez {message.Unread} message(s) non-lus sur {message.Total} dans votre ankabox.",
                    LogMessageType.Default);
        }

        [MessageHandler(NewMailMessage.ProtocolId)]
        private void NewMailMessageHandler(DofusClient client, NewMailMessage message)
        {
            client.Logger.Log($"Ankabox: Vous avez reçu un nouveau message de la part de : {message.SendersAccountId}",
                LogMessageType.Default);
            if (message.Total > 0)
                client.Logger.Log(
                    $"Ankabox: Vous avez {message.Unread} message(s) non-lus sur {message.Total} dans votre ankabox.",
                    LogMessageType.Default);
        }
    }
}