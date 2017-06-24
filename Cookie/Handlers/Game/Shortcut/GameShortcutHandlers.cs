using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Shortcut;

namespace Cookie.Handlers.Game.Shortcut
{
    public class GameShortcutHandlers
    {
        [MessageHandler(ShortcutBarContentMessage.ProtocolId)]
        private void ShortcutBarContentMessageHandler(DofusClient client, ShortcutBarContentMessage message)
        {
            //
        }
    }
}