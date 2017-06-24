using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Secure;

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