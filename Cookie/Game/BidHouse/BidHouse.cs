using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cookie.API.Core;
using Cookie.API.Datacenter;
using Cookie.API.Game.BidHouse;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc;
using Cookie.API.Protocol.Network.Messages.Game.Dialog;
using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.BidHouse
{
    public class BidHouse : IBidHouse
    {
        private readonly IAccount _account;
        private readonly AutoResetEvent _bidHouseActionEvent = new AutoResetEvent(false);
        private readonly List<uint> _itemListInBidHouse;
        private readonly List<uint> _itemTypesInBidHouse;

        private bool _bidHouseBuyDialogIsLoaded;
        private bool _bidHouseSellDialogIsLoaded;

        #region "Constructor"

        public BidHouse(IAccount account)
        {
            _account = account;
            _itemTypesInBidHouse = new List<uint>();
            _itemListInBidHouse = new List<uint>();

            _bidHouseBuyDialogIsLoaded = false;
            _bidHouseSellDialogIsLoaded = false;

            ItemPricesList = new Dictionary<uint, List<ulong>>();
            MeanPrice = 0;

            account.Network.RegisterPacket<ExchangeStartedBidBuyerMessage>(HandleExchangeStartedBidBuyerMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeStartedBidSellerMessage>(HandleExchangeStartedBidSellerMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeLeaveMessage>(HandleExchangeLeaveMessage, MessagePriority.VeryHigh);

            account.Network.RegisterPacket<ExchangeTypesExchangerDescriptionForUserMessage>(
                HandleExchangeTypesExchangerDescriptionForUserMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeTypesItemsExchangerDescriptionForUserMessage>(
                HandleExchangeTypesItemsExchangerDescriptionForUserMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidPriceMessage>(HandleExchangeBidPriceMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseInListUpdatedMessage>(
                HandleExchangeBidHouseInListUpdatedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseInListAddedMessage>(HandleExchangeBidHouseInListAddedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseInListRemovedMessage>(
                HandleExchangeBidHouseInListRemovedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseItemAddOkMessage>(HandleExchangeBidHouseItemAddOkMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseBuyResultMessage>(HandleExchangeBidHouseBuyResultMessage,
                MessagePriority.VeryHigh);
        }

        #endregion

        /* Content of ItemPricesList :
         * Prices[uid][0] = Price of 1 item uid
         * Prices[uid][1] = Price of 10 items uid
         * Prices[uid][2] = Price of 100 items uid
         */
        public Dictionary<uint, List<ulong>> ItemPricesList { get; }

        public long MeanPrice { get; private set; }

        public bool BidHouseNpcOnMapExists()
        {
            return _account.Character.Map.Npcs.Any(npc => npc.Name.StartsWith("Vendeur "));
        }


        #region "Public Functions"

        public async Task<bool> StartBidHouseDialog(NpcActionId ActionId)
        {
            /* Check if NpcAction is correct */
            if (!((ActionId == NpcActionId.BID_HOUSE_BUY) | (ActionId == NpcActionId.BID_HOUSE_SELL)))
                throw new Exception("L'NpcActionId sélectionnée est incorrecte.");

            /* Check if BidHouse Dialog is open */
            if ((_bidHouseBuyDialogIsLoaded & (ActionId == NpcActionId.BID_HOUSE_BUY)) |
                (_bidHouseSellDialogIsLoaded & (ActionId == NpcActionId.BID_HOUSE_SELL))) return true;

            /* Check if BidHouse Npc exists on current map */
            if (!BidHouseNpcOnMapExists())
            {
                _bidHouseBuyDialogIsLoaded = false;
                _bidHouseSellDialogIsLoaded = false;

                throw new Exception("Aucun PNJ d'hôtel de vente n'est présent sur cette map.");
            }

            /* Get Npc data */
            var Npc = _account.Character.Map.Npcs.Find(npc => npc.Name.StartsWith("Vendeur "));
            var npcUId = Convert.ToInt32(Npc.NpcId);
            var npcMapId = Convert.ToInt32(Npc.Id);
            var npcName = Npc.Name;
            var npcActionId = (byte) ActionId;

            var message = new NpcGenericActionRequestMessage
            {
                NpcId = npcMapId,
                NpcActionId = npcActionId,
                NpcMapId = _account.Character.MapId
            };

            Logger.Default.Log($"Ouverture de la fenêtre HDV du PNJ {npcName}({npcMapId})", LogMessageType.Info);

            /* Wait for Bid House dialog to open */
            if (await SendAndWait(message, 3000)) return true;

            throw new Exception("La fenêtre HDV n'a pas pu s'ouvrir.");
        }

        public void ExitBidHouseDialog()
        {
            _account.Network.SendToServer(new LeaveDialogRequestMessage());
        }


        public async Task<bool> LoadItemData(uint itemId)
        {
            /* Init prices */
            ItemPricesList.Clear();
            MeanPrice = 0;

            /* Check if BidHouse Dialog is open */
            if (!_bidHouseBuyDialogIsLoaded) throw new Exception("La fenêtre HDV n'est pas ouverte.");

            /* Request item type of itemid */
            if (!await RequestItemType(itemId)) return false;

            /* We can now request item prices list*/
            if (!await RequestItemPrices(itemId)) return false;

            return true;
        }

        public async Task<bool> SellItem(uint itemUId, int quantity, ulong price)
        {
            /* Check if BidHouse Dialog is open */
            if (!_bidHouseSellDialogIsLoaded) throw new Exception("La fenêtre HDV n'est pas ouverte.");

            /* Check quantity */
            /* We can use log10(|quantity|)%1 */
            if ((quantity != 1) & (quantity != 10) & (quantity != 100))
                throw new Exception("La quantité doit être l'une des suivantes : 1, 10, 100.");

            /* Check if item exists in inventory */
            var item_exists =
                _account.Character.Inventory.Objects.Any(
                    item => (item.ObjectUID == itemUId) &
                            (item.Position == (sbyte) CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED) &
                            (item.Quantity >= quantity));
            if (!item_exists) throw new Exception("Aucun item n'a été trouvé.");

            /* Sell item */
            var SellItemMessage = new ExchangeObjectMovePricedMessage
            {
                Price = price,
                ObjectUID = itemUId,
                Quantity = quantity
            };

            /* Check if item was successfully put in bid house */
            if (await SendAndWait(SellItemMessage, 3000)) return true;

            throw new Exception("L'item n'a pas pu être mis en vente.");
        }

        public async Task<bool> BuyItem(uint itemUId, uint quantity)
        {
            /* Check if BidHouse Dialog is open */
            if (!_bidHouseBuyDialogIsLoaded) throw new Exception("La fenêtre HDV n'est pas ouverte.");

            /* Check quantity */
            /* We can use log10(|quantity|)%1 */
            if ((quantity != 1) & (quantity != 10) & (quantity != 100))
                throw new Exception("La quantité doit être l'une des suivantes : 1, 10, 100.");

            /* Check if item exists in bid house */
            var Prices = new List<ulong>();
            if (!ItemPricesList.TryGetValue(itemUId, out Prices))
                throw new Exception(
                    $"Cet identifiant ({itemUId}) n'existe pas dans la liste des prix ou cette dernière n'a pas été chargée.");

            /* Check if requested quantity exists */
            var Price = Prices[Convert.ToInt32(Math.Log10(quantity))];
            if (!(Price > 0)) throw new Exception($"Cette quantité ({quantity}) n'existe pas pour l'item demandé.");

            Logger.Default.Log($"Achat de {quantity} de l'item portant l'uid {itemUId} au prix de {Price}",
                LogMessageType.Info);
            /* All good, we pay */

            var message = new ExchangeBidHouseBuyMessage
            {
                Uid = itemUId,
                Qty = quantity,
                Price = Price
            };

            /* Check if item was successfully bought */
            if (await SendAndWait(message, 3000)) return true;

            throw new Exception("L'item n'a pas pu être acheté.");
        }

        #endregion

        #region "Private Functions"

        private async Task<bool> SendAndWait(NetworkMessage message, int timeout)
        {
            var TaskToDo = Task.Run(() => { _account.Network.SendToServer(message); })
                .ContinueWith(t => { _bidHouseActionEvent.WaitOne(2 * timeout); },
                    TaskContinuationOptions.OnlyOnRanToCompletion);

            // Task TimeoutAfter logic
            return await Task.WhenAny(TaskToDo, Task.Delay(timeout)) == TaskToDo;
        }

        private async Task<bool> RequestItemType(uint itemId)
        {
            /* Check if item exists in Bid House */
            var itemType = ObjectDataManager.Instance.Get<Item>(itemId).TypeId;
            if (!_itemTypesInBidHouse.Contains(itemType))
                throw new Exception(
                    $"L'item {D2OParsing.GetItemName(itemId)} ({itemId}) n'existe pas dans cet hôtel de vente.");

            var itemsTypeMessage = new ExchangeBidHouseTypeMessage
            {
                Type = itemType
            };

            Logger.Default.Log(
                $"Sélection de la catégorie {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<ItemType>(itemType).NameId)} ({itemType}).",
                LogMessageType.Info);

            if (!await SendAndWait(itemsTypeMessage, 3000))
                throw new Exception(
                    $"Erreur lors de la sélection de la catégorie {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<ItemType>(itemType).NameId)} ({itemType}).");

            /* Check if item exists in items list */
            if (!_itemListInBidHouse.Contains(itemId))
                throw new Exception(
                    $"L'item {D2OParsing.GetItemName(itemId)} ({itemId}) n'est pas actuellement en vente dans cet HDV.");

            return true;
        }

        private async Task<bool> RequestItemPrices(uint itemId)
        {
            var itemsListMessage = new ExchangeBidHouseListMessage
            {
                ObjectId = Convert.ToUInt16(itemId)
            };

            if (!await SendAndWait(itemsListMessage, 3000))
                throw new Exception("Erreur lors de récupération de la liste des prix.");

            var itemPriceMessage = new ExchangeBidHousePriceMessage
            {
                GenId = Convert.ToUInt16(itemId)
            };

            if (!await SendAndWait(itemPriceMessage, 3000))
                throw new Exception("Erreur lors de récupération du prix moyen.");

            return true;
        }

        #endregion

        #region TelegramsHandler

        private void HandleExchangeStartedBidBuyerMessage(IAccount account, ExchangeStartedBidBuyerMessage message)
        {
            _itemListInBidHouse.Clear();
            _itemTypesInBidHouse.Clear();
            _itemTypesInBidHouse.AddRange(message.BuyerDescriptor.Types);

            _bidHouseBuyDialogIsLoaded = true;
            _bidHouseSellDialogIsLoaded = false;

            _bidHouseActionEvent.Set();
        }

        private void HandleExchangeStartedBidSellerMessage(IAccount account, ExchangeStartedBidSellerMessage message)
        {
            _bidHouseBuyDialogIsLoaded = false;
            _bidHouseSellDialogIsLoaded = true;

            _bidHouseActionEvent.Set();
        }

        private void HandleExchangeTypesExchangerDescriptionForUserMessage(IAccount account,
            ExchangeTypesExchangerDescriptionForUserMessage message)
        {
            _itemListInBidHouse.Clear();
            _itemListInBidHouse.AddRange(message.TypeDescription);

            _bidHouseActionEvent.Set();
        }

        private void HandleExchangeTypesItemsExchangerDescriptionForUserMessage(IAccount account,
            ExchangeTypesItemsExchangerDescriptionForUserMessage message)
        {
            ItemPricesList.Clear();
            message.ItemTypeDescriptions.ForEach(item => ItemPricesList.Add(item.ObjectUID, item.Prices));

            _bidHouseActionEvent.Set();
        }

        private void HandleExchangeBidPriceMessage(IAccount account, ExchangeBidPriceMessage message)
        {
            MeanPrice = message.AveragePrice;
            _bidHouseActionEvent.Set();
        }

        private void HandleExchangeLeaveMessage(IAccount account, ExchangeLeaveMessage message)
        {
            _bidHouseBuyDialogIsLoaded = false;
            _bidHouseSellDialogIsLoaded = false;
        }

        private void HandleExchangeBidHouseInListUpdatedMessage(IAccount account,
            ExchangeBidHouseInListUpdatedMessage message)
        {
        }

        private void HandleExchangeBidHouseInListAddedMessage(IAccount account,
            ExchangeBidHouseInListAddedMessage message)
        {
        }

        private void HandleExchangeBidHouseInListRemovedMessage(IAccount account,
            ExchangeBidHouseInListRemovedMessage message)
        {
        }

        private void HandleExchangeBidHouseItemAddOkMessage(IAccount account, ExchangeBidHouseItemAddOkMessage message)
        {
            var unsoldDelayHours = message.ItemInfo.UnsoldDelay / 3600;
            var objectGID = message.ItemInfo.ObjectGID;
            var objectName = D2OParsing.GetItemName(objectGID);
            var quantity = message.ItemInfo.Quantity;
            var objectPrice = message.ItemInfo.ObjectPrice;

            Logger.Default.Log(
                $"{quantity}x{objectName} mis vente en HDV pour {objectPrice} kamas et pour une durée de {unsoldDelayHours}h");

            _bidHouseActionEvent.Set();
        }

        private void HandleExchangeBidHouseBuyResultMessage(IAccount account, ExchangeBidHouseBuyResultMessage message)
        {
            if (message.Bought) _bidHouseActionEvent.Set();
        }

        #endregion
    }
}