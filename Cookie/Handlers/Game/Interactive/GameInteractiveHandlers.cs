using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Interactive;

namespace Cookie.Handlers.Game.Interactive
{
    public class GameInteractiveHandlers
    {
        [MessageHandler(InteractiveUseRequestMessage.ProtocolId)]
        private void InteractiveUseRequestMessageHandler(DofusClient Client, InteractiveUseRequestMessage Message)
        {
            //
        }

        [MessageHandler(InteractiveUsedMessage.ProtocolId)]
        private void InteractiveUsedMessageHandler(DofusClient Client, InteractiveUsedMessage Message)
        {
            //
        }

        [MessageHandler(InteractiveUseEndedMessage.ProtocolId)]
        private void InteractiveUseEndedMessageHandler(DofusClient Client, InteractiveUseEndedMessage Message)
        {
            //
        }

        [MessageHandler(StatedElementUpdatedMessage.ProtocolId)]
        private void StatedElementUpdatedMessageHandler(DofusClient Client, StatedElementUpdatedMessage Message)
        {
            //
        }

        [MessageHandler(InteractiveElementUpdatedMessage.ProtocolId)]
        private void InteractiveElementUpdatedMessageHandler(DofusClient Client, InteractiveElementUpdatedMessage Message)
        {
            //
        }
    }
}
