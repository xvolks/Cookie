using Cookie.Core;
using Cookie.Protocol.Network.Messages.Secure;

namespace Cookie.Handlers.Secure
{
    public class SecureHandlers
    {
        [MessageHandler(TrustStatusMessage.ProtocolId)]
        private void TrustStatusMessageHandler(DofusClient client, TrustStatusMessage message)
        {
            //
        }
    }
}
