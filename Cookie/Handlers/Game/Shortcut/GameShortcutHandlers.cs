using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Shortcut
{
    public class GameShortcutHandlers
    {
        [MessageHandler(ShortcutBarContentMessage.ProtocolId)]
        private void ShortcutBarContentMessageHandler(DofusClient Client, ShortcutBarContentMessage Message)
        {
            //
        }
    }
}
