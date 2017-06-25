using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Inventory;
using Cookie.Core;

namespace Cookie.Handlers.Game.Inventory
{
    public class GameInventoryHandlers
    {
        [MessageHandler(KamasUpdateMessage.ProtocolId)]
        private void KamasUpdateMessageHandler(DofusClient client, KamasUpdateMessage message)
        {
            client.Account.Character.Stats.Kamas = message.KamasTotal;
        }

        [MessageHandler(ObjectAveragePricesErrorMessage.ProtocolId)]
        private void ObjectAveragePricesErrorMessageHandler(DofusClient client, ObjectAveragePricesErrorMessage message)
        {
            //
        }

        [MessageHandler(ObjectAveragePricesMessage.ProtocolId)]
        private void ObjectAveragePricesMessageHandler(DofusClient client, ObjectAveragePricesMessage message)
        {
            //
        }
    }
}