using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Handshake
{
    public class HandshakeHandlers
    {
        [MessageHandler(ProtocolRequired.ProtocolId)]
        private void ProtocolRequiredHandler(DofusClient Client, ProtocolRequired Message)
        {
            //
            //Client.Logger.Log(string.Format("{0},{1},{2}", Message.CurrentVersion, Message.MessageID, Message.RequiredVersion));
        }
    }
}
