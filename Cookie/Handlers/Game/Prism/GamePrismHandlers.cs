using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Prism;

namespace Cookie.Handlers.Game.Prism
{
    public class GamePrismHandlers
    {
        [MessageHandler(PrismsListMessage.ProtocolId)]
        private void PrismsListMessageHandler(DofusClient Client, PrismsListMessage Message)
        {
            //
        }

        [MessageHandler(PrismsListUpdateMessage.ProtocolId)]
        private void PrismsListUpdateMessageHandler(DofusClient Client, PrismsListUpdateMessage Message)
        {
            //
        }
    }
}
