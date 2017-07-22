using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Cookie.API.Core;
using Cookie.API.Game.BidHouse;
using Cookie.API.Messages;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Dialog;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc;
using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;


namespace Cookie.Game.BidHouse
{
    public enum BidHouseNpcActionId
    {
        BID_HOUSE_SELL = 5,
        BID_HOUSE_BUY = 6
    }

    public class BidHouse : IBidHouse
    {

        private readonly IAccount _account;
        private readonly List<uint> _itemTypesInBidHouse;
        private readonly List<uint> _itemListInBidHouse;

        private bool _bidHouseDialogIsLoaded;
        private bool _bidHouseItemTypeIsLoaded;
        private bool _bidHouseItemQuantityPriceIsLoaded;
        private bool _bidHouseItemMeanPriceIsLoaded;

        /* Content of ItemPricesList :
         * Prices[i][0] = Price of 1 item in position i
         * Prices[i][1] = Price of 10 items in position i
         * Prices[i][2] = Price of 100 items in position i
         */
        public List<List<ulong>> ItemPricesList { get; }
        public long MeanPrice { get; private set; }

        public bool BidHouseNpcOnMapExists() => _account.Character.Map.Npcs.Any(npc => npc.Name.StartsWith("Vendeur "));

        #region "Constructor"

        public BidHouse(IAccount account)
        {
            _account = account;
            _itemTypesInBidHouse = new List<uint>();
            _itemListInBidHouse = new List<uint>();

            _bidHouseDialogIsLoaded = false;
            _bidHouseItemTypeIsLoaded = false;
            _bidHouseItemQuantityPriceIsLoaded = false;
            _bidHouseItemMeanPriceIsLoaded = false;

            ItemPricesList = new List<List<ulong>>();
            MeanPrice = 0;

            account.Network.RegisterPacket<ExchangeStartedBidBuyerMessage>(HandleExchangeStartedBidBuyerMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeStartedBidSellerMessage>(HandleExchangeStartedBidSellerMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeTypesExchangerDescriptionForUserMessage>(HandleExchangeTypesExchangerDescriptionForUserMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeTypesItemsExchangerDescriptionForUserMessage>(HandleExchangeTypesItemsExchangerDescriptionForUserMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidPriceMessage>(HandleExchangeBidPriceMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeLeaveMessage>(HandleExchangeLeaveMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseInListUpdatedMessage>(HandleExchangeBidHouseInListUpdatedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseInListAddedMessage>(HandleExchangeBidHouseInListAddedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidHouseInListRemovedMessage>(HandleExchangeBidHouseInListRemovedMessage, MessagePriority.VeryHigh);
        }

        #endregion


        #region "Public Functions"

        public async Task<bool> StartBidHouseDialog(BidHouseNpcActionId ActionId)
        {

            /* Check if BidHouse Dialog is open */
            if (_bidHouseDialogIsLoaded) return true;

            /* Check if BidHouse Npc exists on current map */
            if (!BidHouseNpcOnMapExists())
            {
                _bidHouseDialogIsLoaded = false;
                _bidHouseItemTypeIsLoaded = false;
                _bidHouseItemQuantityPriceIsLoaded = false;
                _bidHouseItemMeanPriceIsLoaded = false;

                throw new Exception("Aucun PNJ d'hôtel de vente n'est présent sur cette map.");
            }

            /* Get Npc data */
            var Npc = _account.Character.Map.Npcs.Find(npc => npc.Name.StartsWith("Vendeur "));
            var npcUId = Convert.ToInt32(Npc.NpcId);
            var npcMapId = Convert.ToInt32(Npc.Id);
            var npcName = Npc.Name;
            var npcActionId = (byte)ActionId;

            var message = new NpcGenericActionRequestMessage()
            {
                NpcId = npcMapId,
                NpcActionId = npcActionId,
                NpcMapId = _account.Character.MapId
            };

            _account.Network.SendToServer(message);


            Logger.Default.Log($"Ouverture de la fenêtre HDV du PNJ {npcName}({npcMapId})", LogMessageType.Info);

            /* Wait for Bid House dialog to open */
            var source = new CancellationTokenSource();
            var t = Task.Run(() => { while (!_bidHouseDialogIsLoaded) { if (source.IsCancellationRequested) break; } }, source.Token);
            if (await Task.WhenAny(t, Task.Delay(3000, source.Token)) == t) return true;

            source.Cancel();

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
            if (!_bidHouseDialogIsLoaded) throw new Exception("La fenêtre HDV n'est pas ouverte.");

            /* Request item type of itemid */
            if (!RequestItemType(itemId)) return false;

            /* Check if item type is loaded */
            var source = new CancellationTokenSource();
            var checkTypeTask = Task.Run(() => { while (!_bidHouseItemTypeIsLoaded) { if (source.IsCancellationRequested) break; } }, source.Token);
            if (await Task.WhenAny(checkTypeTask, Task.Delay(3000, source.Token)) != checkTypeTask)
            {
                source.Cancel();
                ExitBidHouseDialog();
                throw new Exception("La liste des items n'a pas pu s'ouvrir.");
            }

            /* We can now request item prices list*/
            RequestItemPrices(itemId);

            /* Check if prices are loaded */
            source = new CancellationTokenSource();
            var checkPriceTask = Task.Run(() => { while (!_bidHouseItemQuantityPriceIsLoaded || !_bidHouseItemMeanPriceIsLoaded) { if (source.IsCancellationRequested) break; } }, source.Token);
            if (await Task.WhenAny(checkPriceTask, Task.Delay(3000, source.Token)) == checkPriceTask) return true;

            source.Cancel();
            ExitBidHouseDialog();
            throw new Exception("La liste des prix de l'item n'a pas pu être chargée.");

        }

        public void SellItem(uint itemUId, int quantity, ulong price)
        {
            
            /* Check if BidHouse Dialog is open */
            if (!_bidHouseDialogIsLoaded) throw new Exception("La fenêtre HDV n'est pas ouverte.");

            /* Check quantity */
            /* We can use log10(|quantity|)%1 */
            if (quantity != 1 & quantity != 10 & quantity != 100) throw new Exception("La quantité doit être l'une des suivantes : 1, 10, 100.");

            _account.Character.Inventory.Objects.ForEach(item => Logger.Default.Log($"{D2OParsing.GetItemName(item.ObjectGID)} - {item.ObjectUID} - {item.Position} - {item.Quantity} - {item.TypeID}"));

            /* Check if item exists in inventory */
            bool item_exists = _account.Character.Inventory.Objects.Any(item => (item.ObjectUID == itemUId) & (item.Position == (sbyte)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED) & (item.Quantity >= quantity));
            if(!item_exists) throw new Exception("Aucun item n'a été trouvé.");

            /* Sell item */
            var SellItemMessage = new ExchangeObjectMovePricedMessage()
            {
                Price = price,
                ObjectUID = itemUId,
                Quantity = quantity
            };

        }

        #endregion

        #region "Private Functions"

        private bool RequestItemType(uint itemId)
        {
            /* Check if item exists in Bid House */
            var itemType = ObjectDataManager.Instance.Get<API.Datacenter.Item>(itemId).TypeId;
            if (!_itemTypesInBidHouse.Contains(itemType))
            {
                ExitBidHouseDialog();
                throw new Exception($"L'item {D2OParsing.GetItemName(itemId)} ({itemId}) n'existe pas dans cet hôtel de vente.");
            }

            var itemsTypeMessage = new ExchangeBidHouseTypeMessage()
            {
                Type = itemType
            };

            _account.Network.SendToServer(itemsTypeMessage);
            Logger.Default.Log($"Sélection de la catégorie {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<API.Datacenter.ItemType>(itemType).NameId)} ({itemType}).", LogMessageType.Info);

            return true;
        }

        private void RequestItemPrices(uint itemId)
        {

            var itemsListMessage = new ExchangeBidHouseListMessage()
            {
                ObjectId = Convert.ToUInt16(itemId)
            };
            _account.Network.SendToServer(itemsListMessage);

            var itemPriceMessage = new ExchangeBidHousePriceMessage()
            {
                GenId = Convert.ToUInt16(itemId)
            };
            _account.Network.SendToServer(itemPriceMessage);
        }

        #endregion

        #region TelegramsHandler

        private void HandleExchangeStartedBidBuyerMessage(IAccount account, ExchangeStartedBidBuyerMessage message)
        {
            _itemTypesInBidHouse.Clear();
            _itemTypesInBidHouse.AddRange(message.BuyerDescriptor.Types);

            _bidHouseDialogIsLoaded = true;

        }

        private void HandleExchangeStartedBidSellerMessage(IAccount account, ExchangeStartedBidSellerMessage message)
        {
            
        }

        private void HandleExchangeTypesExchangerDescriptionForUserMessage(IAccount account, ExchangeTypesExchangerDescriptionForUserMessage message)
        {
            _itemListInBidHouse.Clear();
            _itemListInBidHouse.AddRange(message.TypeDescription);

            _bidHouseItemTypeIsLoaded = true;
        }

        private void HandleExchangeTypesItemsExchangerDescriptionForUserMessage(IAccount account, ExchangeTypesItemsExchangerDescriptionForUserMessage message)
        {
            ItemPricesList.Clear();
            message.ItemTypeDescriptions.ForEach(item => ItemPricesList.Add(item.Prices));

            _bidHouseItemQuantityPriceIsLoaded = true;

        }

        private void HandleExchangeBidPriceMessage(IAccount account, ExchangeBidPriceMessage message)
        {
            MeanPrice = message.AveragePrice;
            _bidHouseItemMeanPriceIsLoaded = true;
        }

        private void HandleExchangeLeaveMessage(IAccount account, ExchangeLeaveMessage message)
        {
            _bidHouseDialogIsLoaded = false;
            _bidHouseItemTypeIsLoaded = false;
            _bidHouseItemQuantityPriceIsLoaded = false;
            _bidHouseItemMeanPriceIsLoaded = false;
        }

        private void HandleExchangeBidHouseInListUpdatedMessage(IAccount account, ExchangeBidHouseInListUpdatedMessage message)
        {
            
        }

        private void HandleExchangeBidHouseInListAddedMessage(IAccount account, ExchangeBidHouseInListAddedMessage message)
        {

        }

        private void HandleExchangeBidHouseInListRemovedMessage(IAccount account, ExchangeBidHouseInListRemovedMessage message)
        {
            
        }

        #endregion



    }
}