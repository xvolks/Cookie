using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Script;

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
