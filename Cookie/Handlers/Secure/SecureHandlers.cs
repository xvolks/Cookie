using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Secure;
using Cookie.Core;

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