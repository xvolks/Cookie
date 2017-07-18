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
        private readonly List<uint> _itemListInBidHouse;
        private readonly List<uint> _itemTypesInBidHouse;

        private bool _bidHouseDialogIsLoaded;
        private bool _bidHouseItemMeanPriceIsLoaded;
        private bool _bidHouseItemQuantityPriceIsLoaded;
        private bool _bidHouseItemTypeIsLoaded;

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

            account.Network.RegisterPacket<ExchangeStartedBidBuyerMessage>(HandleExchangeStartedBidBuyerMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeTypesExchangerDescriptionForUserMessage>(
                HandleExchangeTypesExchangerDescriptionForUserMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeTypesItemsExchangerDescriptionForUserMessage>(
                HandleExchangeTypesItemsExchangerDescriptionForUserMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeBidPriceMessage>(HandleExchangeBidPriceMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeLeaveMessage>(HandleExchangeLeaveMessage, MessagePriority.VeryHigh);
        }

        #endregion

        /* Content of ItemPricesList :
         * Prices[i][0] = Price of 1 item in position i
         * Prices[i][1] = Price of 10 items in position i
         * Prices[i][2] = Price of 100 items in position i
         */
        public List<List<ulong>> ItemPricesList { get; }

        public long MeanPrice { get; private set; }

        public bool BidHouseNpcOnMapExists()
        {
            return _account.Character.Map.Npcs.Any(npc => npc.Name.StartsWith("Vendeur "));
        }


        #region "Public Functions"

        public async Task<bool> StartBidHouseDialog()
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
            var npcId = Convert.ToInt32(_account.Character.Map.Npcs.Find(npc => npc.Name.StartsWith("Vendeur ")).Id);
            var npcName = _account.Character.Map.Npcs.Find(npc => npc.Name.StartsWith("Vendeur ")).Name;
            var npcActionId = (byte) 6; /*TODO : Change 6 with its enum*/

            var message = new NpcGenericActionRequestMessage
            {
                NpcId = npcId,
                NpcActionId = npcActionId,
                NpcMapId = _account.Character.MapId
            };

            _account.Network.SendToServer(message);


            Logger.Default.Log($"Ouverture de la fenêtre HDV du PNJ {npcName}({npcId})", LogMessageType.Info);

            /* Wait for Bid House dialog to open */
            var source = new CancellationTokenSource();
            var t = Task.Run(() =>
            {
                while (!_bidHouseDialogIsLoaded) if (source.IsCancellationRequested) break;
            }, source.Token);
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
            var checkTypeTask = Task.Run(() =>
            {
                while (!_bidHouseItemTypeIsLoaded) if (source.IsCancellationRequested) break;
            }, source.Token);
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
            var checkPriceTask = Task.Run(() =>
            {
                while (!_bidHouseItemQuantityPriceIsLoaded || !_bidHouseItemMeanPriceIsLoaded)
                    if (source.IsCancellationRequested) break;
            }, source.Token);
            if (await Task.WhenAny(checkPriceTask, Task.Delay(3000, source.Token)) == checkPriceTask) return true;

            source.Cancel();
            ExitBidHouseDialog();
            throw new Exception("La liste des prix de l'item n'a pas pu être chargée.");
        }

        #endregion

        #region "Private Functions"

        private bool RequestItemType(uint itemId)
        {
            /* Check if item exists in Bid House */
            var itemType = ObjectDataManager.Instance.Get<Item>(itemId).TypeId;
            if (!_itemTypesInBidHouse.Contains(itemType))
            {
                ExitBidHouseDialog();
                throw new Exception(
                    $"L'item {D2OParsing.GetItemName(itemId)} ({itemId}) n'existe pas dans cet hôtel de vente.");
            }

            var itemsTypeMessage = new ExchangeBidHouseTypeMessage
            {
                Type = itemType
            };

            _account.Network.SendToServer(itemsTypeMessage);
            Logger.Default.Log(
                $"Sélection de la catégorie {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<ItemType>(itemType).NameId)} ({itemType}).",
                LogMessageType.Info);

            return true;
        }

        private void RequestItemPrices(uint itemId)
        {
            var itemsListMessage = new ExchangeBidHouseListMessage
            {
                ObjectId = Convert.ToUInt16(itemId)
            };
            _account.Network.SendToServer(itemsListMessage);

            var itemPriceMessage = new ExchangeBidHousePriceMessage
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

        private void HandleExchangeTypesExchangerDescriptionForUserMessage(IAccount account,
            ExchangeTypesExchangerDescriptionForUserMessage message)
        {
            _itemListInBidHouse.Clear();
            _itemListInBidHouse.AddRange(message.TypeDescription);

            _bidHouseItemTypeIsLoaded = true;
        }

        private void HandleExchangeTypesItemsExchangerDescriptionForUserMessage(IAccount account,
            ExchangeTypesItemsExchangerDescriptionForUserMessage message)
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

        #endregion
    }
}