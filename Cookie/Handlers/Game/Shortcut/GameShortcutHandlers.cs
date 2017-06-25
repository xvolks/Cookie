using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Shortcut;
using Cookie.Core;

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