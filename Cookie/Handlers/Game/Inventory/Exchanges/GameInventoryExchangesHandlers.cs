using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Inventory.Exchanges;

namespace Cookie.Handlers.Game.Inventory.Exchanges
{
    public class GameInventoryExchangesHandlers
    {
        [MessageHandler(ExchangeBidHouseUnsoldItemsMessage.ProtocolId)]
        private void ExchangeBidHouseUnsoldItemsMessageHandler(DofusClient client, ExchangeBidHouseUnsoldItemsMessage message)
        {
            //
        }

        [MessageHandler(ExchangeOfflineSoldItemsMessage.ProtocolId)]
        private void ExchangeOfflineSoldItemsMessageHandler(DofusClient client, ExchangeOfflineSoldItemsMessage message)
        {
            //
        }
    }
}
