using System;
using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Handshake;

namespace Cookie.Handlers.Handshake
{
    public class HandshakeHandlers
    {
        [MessageHandler(ProtocolRequired.ProtocolId)]
        private void ProtocolRequiredHandler(DofusClient client, ProtocolRequired message)
        {
            //
            client.Logger.Log($"[BOT] CurrentVersion: {message.CurrentVersion} / RequiredVersion {message.RequiredVersion}", LogMessageType.Info);
        }
    }
}