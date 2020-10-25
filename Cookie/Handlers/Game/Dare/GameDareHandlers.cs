using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Dare
{
    public class GameDareHandlers
    {
        [MessageHandler(DareCreatedListMessage.ProtocolId)]
        private void DareCreatedListMessageHandler(DofusClient Client, DareCreatedListMessage Message)
        {
            //
        }

        [MessageHandler(DareSubscribedListMessage.ProtocolId)]
        private void DareSubscribedListMessageHandler(DofusClient Client, DareSubscribedListMessage Message)
        {
            //
        }

        [MessageHandler(DareWonListMessage.ProtocolId)]
        private void DareWonListMessageHandler(DofusClient Client, DareWonListMessage Message)
        {
            //
        }

        [MessageHandler(DareRewardsListMessage.ProtocolId)]
        private void DareRewardsListMessageHandler(DofusClient Client, DareRewardsListMessage Message)
        {
            //
        }
    }
}
