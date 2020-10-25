using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Secure
{
    public class SecureHandlers
    {
        [MessageHandler(TrustStatusMessage.ProtocolId)]
        private void TrustStatusMessageHandler(DofusClient Client, TrustStatusMessage Message)
        {
            //
        }
    }
}
