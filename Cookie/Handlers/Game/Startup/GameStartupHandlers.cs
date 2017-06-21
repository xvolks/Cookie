using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Startup;

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