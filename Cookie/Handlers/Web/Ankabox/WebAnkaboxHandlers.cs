using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Web.Ankabox;
using Cookie.Core;

namespace Cookie.Handlers.Web.Ankabox
{
    public class WebAnkaboxHandlers
    {
        [MessageHandler(MailStatusMessage.ProtocolId)]
        private void MailStatusMessageHandler(DofusClient client, MailStatusMessage message)
        {
            if (message.Total > 0)
                Logger.Default.Log(
                    $"Ankabox: Vous avez {message.Unread} message(s) non-lus sur {message.Total} dans votre ankabox.",
                    LogMessageType.Default);
        }

        [MessageHandler(NewMailMessage.ProtocolId)]
        private void NewMailMessageHandler(DofusClient client, NewMailMessage message)
        {
            Logger.Default.Log($"Ankabox: Vous avez reçu un nouveau message de la part de : {message.SendersAccountId}",
                LogMessageType.Default);
            if (message.Total > 0)
                Logger.Default.Log(
                    $"Ankabox: Vous avez {message.Unread} message(s) non-lus sur {message.Total} dans votre ankabox.",
                    LogMessageType.Default);
        }
    }
}