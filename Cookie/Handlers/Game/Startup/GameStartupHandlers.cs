using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Startup
{
    public class GameStartupHandlers
    {
        [MessageHandler(StartupActionsListMessage.ProtocolId)]
        private void StartupActionsListMessageHandler(DofusClient Client, StartupActionsListMessage Message)
        {
            //
        }
    }
}
