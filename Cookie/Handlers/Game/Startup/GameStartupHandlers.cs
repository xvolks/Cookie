using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Startup;
using Cookie.Core;

namespace Cookie.Handlers.Game.Startup
{
    public class GameStartupHandlers
    {
        [MessageHandler(StartupActionsListMessage.ProtocolId)]
        private void StartupActionsListMessageHandler(DofusClient client, StartupActionsListMessage message)
        {
            //
        }
    }
}