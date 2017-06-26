using Cookie.API.Gamedata;
using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core;

namespace Cookie.Handlers.Game.Inventory.Exchanges
{
    public class GameInventoryExchangesHandlers
    {
        [MessageHandler(ExchangeBidHouseUnsoldItemsMessage.ProtocolId)]
        private void ExchangeBidHouseUnsoldItemsMessageHandler(DofusClient client,
            ExchangeBidHouseUnsoldItemsMessage message)
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
            Logger.Default.Log($"Le joueur id: {message.Source} vous demande en échange.", LogMessageType.Info);
            client.Send(new ExchangeAcceptMessage());
        }

        [MessageHandler(ExchangeLeaveMessage.ProtocolId)]
        private void ExchangeLeaveMessageHandler(DofusClient client, ExchangeLeaveMessage message)
        {
            client.Account.Character.Status = CharacterStatus.None;
            if (!message.Success)
                Logger.Default.Log("Echange annulé.", LogMessageType.Info);
        }

        [MessageHandler(ExchangeErrorMessage.ProtocolId)]
        private void ExchangeErrorMessageHandler(DofusClient client, ExchangeErrorMessage message)
        {
            Logger.Default.Log("Un erreur est survenue lors de l'échange.", LogMessageType.Info);
        }

        [MessageHandler(ExchangeStartedWithPodsMessage.ProtocolId)]
        private void ExchangeStartedWithPodsMessageHandler(DofusClient client, ExchangeStartedWithPodsMessage message)
        {
            Logger.Default.Log("Vous avez accepté l'échange.", LogMessageType.Info);
            client.Account.Character.Status = CharacterStatus.Exchanging;
            if (message.FirstCharacterId == client.Account.Character.Id)
            {
                client.Account.Character.Weight = message.FirstCharacterCurrentWeight;
                client.Account.Character.MaxWeight = message.FirstCharacterMaxWeight;
                Logger.Default.Log(
                    $"Vous avez {message.FirstCharacterCurrentWeight} / {message.FirstCharacterMaxWeight} pods",
                    LogMessageType.Info);
                Logger.Default.Log(
                    $"L'échangeur a {message.SecondCharacterCurrentWeight} / {message.SecondCharacterMaxWeight} pods",
                    LogMessageType.Info);
            }
            else if (message.SecondCharacterId == client.Account.Character.Id)
            {
                Logger.Default.Log(
                    $"Vous avez {message.SecondCharacterCurrentWeight} / {message.SecondCharacterMaxWeight} pods",
                    LogMessageType.Info);
                Logger.Default.Log(
                    $"L'échangeur a {message.FirstCharacterCurrentWeight} / {message.FirstCharacterMaxWeight} pods",
                    LogMessageType.Info);
                client.Account.Character.Weight = message.SecondCharacterCurrentWeight;
                client.Account.Character.MaxWeight = message.SecondCharacterMaxWeight;
            }
        }

        [MessageHandler(ExchangeObjectAddedMessage.ProtocolId)]
        private void ExchangeObjectAddedMessageHandler(DofusClient client, ExchangeObjectAddedMessage message)
        {
            Logger.Default.Log(
                message.Remote
                    ? $"L'échangeur a ajouté {D2OParsing.GetItemName(message.Object.ObjectGID)} x{message.Object.Quantity} à l'échange"
                    : $"Vous avez ajouté {D2OParsing.GetItemName(message.Object.ObjectGID)} x{message.Object.Quantity} à l'échange",
                LogMessageType.Info);
        }

        [MessageHandler(ExchangeIsReadyMessage.ProtocolId)]
        private void ExchangeIsReadyMessageHandler(DofusClient client, ExchangeIsReadyMessage message)
        {
            if (message.Ready)
                Logger.Default.Log("Le joueur a accepté son échange", LogMessageType.Info);
        }
    }
}