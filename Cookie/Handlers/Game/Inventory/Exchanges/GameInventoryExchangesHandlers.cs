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
        [MessageHandler(ExchangeRequestedTradeMessage.ProtocolId)]
        private void ExchangeRequestedTradeMessageHandler(DofusClient client, ExchangeRequestedTradeMessage message)
        {
            client.Logger.Log($"Le joueur id: {message.Source} vous demande en échange.", LogMessageType.Info);
        }
        [MessageHandler(ExchangeLeaveMessage.ProtocolId)]
        private void ExchangeLeaveMessageHandler(DofusClient client, ExchangeLeaveMessage message)
        {
            if (!message.Success)
            client.Logger.Log($"Le joueur a refusé l'échange.", LogMessageType.Info);
        }
    }
}
