using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Inventory;

namespace Cookie.Handlers.Game.Inventory
{
    public class GameInventoryHandlers
    {
        [MessageHandler(KamasUpdateMessage.ProtocolId)]
        private void KamasUpdateMessageHandler(DofusClient Client, KamasUpdateMessage Message)
        {
            //
        }

        [MessageHandler(ObjectAveragePricesErrorMessage.ProtocolId)]
        private void ObjectAveragePricesErrorMessageHandler(DofusClient Client, ObjectAveragePricesErrorMessage Message)
        {
            //
        }

        [MessageHandler(ObjectAveragePricesGetMessage.ProtocolId)]
        private void ObjectAveragePricesGetMessageHandler(DofusClient Client, ObjectAveragePricesGetMessage Message)
        {
            //
        }

        [MessageHandler(ObjectAveragePricesMessage.ProtocolId)]
        private void ObjectAveragePricesMessageHandler(DofusClient Client, ObjectAveragePricesMessage Message)
        {
            //
        }
    }
}
