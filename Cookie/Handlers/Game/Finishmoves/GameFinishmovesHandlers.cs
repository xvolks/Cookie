using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Finishmoves;

namespace Cookie.Handlers.Game.Finishmoves
{
    public class GameFinishmovesHandlers
    {
        [MessageHandler(FinishMoveListMessage.ProtocolId)]
        private void FinishMoveListMessageHandler(DofusClient client, FinishMoveListMessage message)
        {
            //
        }

        [MessageHandler(FinishMoveListRequestMessage.ProtocolId)]
        private void FinishMoveListRequestMessageHandler(DofusClient client, FinishMoveListRequestMessage message)
        {
            //
        }

        [MessageHandler(FinishMoveSetRequestMessage.ProtocolId)]
        private void FinishMoveSetRequestMessageHandler(DofusClient client, FinishMoveSetRequestMessage message)
        {
            //
        }
    }
}