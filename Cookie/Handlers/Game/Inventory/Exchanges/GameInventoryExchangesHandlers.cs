using Cookie.Core;
using Cookie.Gamedata;
using Cookie.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.Protocol.Network.Messages.Game.Inventory.Items;

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
            client.Send(new ExchangeAcceptMessage());
        }        
        [MessageHandler(ExchangeLeaveMessage.ProtocolId)]
        private void ExchangeLeaveMessageHandler(DofusClient client, ExchangeLeaveMessage message)
        {
            if (!message.Success)
            client.Logger.Log("Echange annulé.", LogMessageType.Info);
        }
        [MessageHandler(ExchangeErrorMessage.ProtocolId)]
        private void ExchangeErrorMessageHandler(DofusClient client, ExchangeErrorMessage message)
        {         
            client.Logger.Log("Un erreur est survenue lors de l'échange.", LogMessageType.Info);
        }
        [MessageHandler(ExchangeStartedWithPodsMessage.ProtocolId)]
        private void ExchangeStartedWithPodsMessageHandler(DofusClient client, ExchangeStartedWithPodsMessage message)
        {
            client.Logger.Log("Vous avez accepté l'échange.", LogMessageType.Info);
            if (message.FirstCharacterId == client.Account.Character.Id)
            {
                client.Account.Character.Weight = message.FirstCharacterCurrentWeight;
                client.Account.Character.MaxWeight = message.FirstCharacterMaxWeight;
                client.Logger.Log($"Vous avez {message.FirstCharacterCurrentWeight} / {message.FirstCharacterMaxWeight} pods", LogMessageType.Info);
                client.Logger.Log($"L'échangeur a {message.SecondCharacterCurrentWeight} / {message.SecondCharacterMaxWeight} pods", LogMessageType.Info);
            }
            else if(message.SecondCharacterId == client.Account.Character.Id)
            {
                client.Logger.Log($"Vous avez {message.SecondCharacterCurrentWeight} / {message.SecondCharacterMaxWeight} pods", LogMessageType.Info);
                client.Logger.Log($"L'échangeur a {message.FirstCharacterCurrentWeight} / {message.FirstCharacterMaxWeight} pods", LogMessageType.Info);
                client.Account.Character.Weight = message.SecondCharacterCurrentWeight;
                client.Account.Character.MaxWeight = message.SecondCharacterMaxWeight;
            }         
        }
        [MessageHandler(ExchangeObjectAddedMessage.ProtocolId)]
        private void ExchangeObjectAddedMessageHandler(DofusClient client, ExchangeObjectAddedMessage message)
        {
            if(message.Remote)
                client.Logger.Log($"L'échangeur a ajouté {D2OParsing.GetItemName(message.Object.ObjectGID)} à l'échange", LogMessageType.Info);
            else
                client.Logger.Log($"Vous avez ajouté {D2OParsing.GetItemName(message.Object.ObjectGID)} à l'échange", LogMessageType.Info);
        }
        
    }
}
