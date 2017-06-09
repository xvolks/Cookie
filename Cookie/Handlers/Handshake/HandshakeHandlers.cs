using Cookie.Core;
using Cookie.Protocol.Network.Messages.Handshake;

namespace Cookie.Handlers.Handshake
{
    public class HandshakeHandlers
    {
        [MessageHandler(ProtocolRequired.ProtocolId)]
        private void ProtocolRequiredHandler(DofusClient Client, ProtocolRequired Message)
        {
            //
        }
    }
}
