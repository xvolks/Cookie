using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Idol;

namespace Cookie.Handlers.Game.Idol
{
    public class GameIdolHandlers
    {
        [MessageHandler(IdolListMessage.ProtocolId)]
        private void IdolListMessageHandler(DofusClient client, IdolListMessage message)
        {
            //
        }
    }
}