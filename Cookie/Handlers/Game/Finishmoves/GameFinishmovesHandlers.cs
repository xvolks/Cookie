using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Finishmoves;

namespace Cookie.Handlers.Game.Finishmoves
{
    public class GameFinishmovesHandlers
    {
        [MessageHandler(FinishMoveListMessage.ProtocolId)]
        private void FinishMoveListMessageHandler(DofusClient Client, FinishMoveListMessage Message)
        {
            //
        }

        [MessageHandler(FinishMoveListRequestMessage.ProtocolId)]
        private void FinishMoveListRequestMessageHandler(DofusClient Client, FinishMoveListRequestMessage Message)
        {
            //
        }

        [MessageHandler(FinishMoveSetRequestMessage.ProtocolId)]
        private void FinishMoveSetRequestMessageHandler(DofusClient Client, FinishMoveSetRequestMessage Message)
        {
            //
        }
    }
}
