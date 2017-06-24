using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Script;

namespace Cookie.Handlers.Game.Script
{
    public class GameScriptHandlers
    {
        [MessageHandler(CinematicMessage.ProtocolId)]
        private void CinematicMessageHandler(DofusClient client, CinematicMessage message)
        {
            //
        }
    }
}