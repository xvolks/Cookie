using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Idol
{
    public class GameIdolHandlers
    {
        [MessageHandler(IdolListMessage.ProtocolId)]
        private void IdolListMessageHandler(DofusClient Client, IdolListMessage Message)
        {
            //
        }
    }
}
