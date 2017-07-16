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
using Cookie.API.Protocol.Network.Messages.Game.Dialog;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc;
using Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;


namespace Cookie.Game.BidHouse
{
    public class BidHouse : IBidHouse
    {

        private readonly IAccount _account;
        private List<uint> _ItemTypesInBidHouse;
        private List<uint> _ItemListInBidHouse;

        private bool _BidHouseDialogIsLoaded;
        private bool _BidHouseItemTypeIsLoaded;
        private bool _BidHouseItemQuantityPriceIsLoaded;
        private bool _BidHouseItemMeanPriceIsLoaded;

        /* Content of ItemPricesList :
         * Prices[i][0] = Price of 1 item in position i
         * Prices[i][1] = Price of 10 items in position i
         * Prices[i][2] = Price of 100 items in position i
         */
        public List<List<ulong>> ItemPricesList { get; private set; }
        public long MeanPrice { get; private set; }

        public bool BidHouseNpcOnMapExists() => _account.Character.Map.Npcs.Any(npc => npc.Name.StartsWith("Vendeur "));

        #region "Constructor"

        public BidHouse(IAccount account)
        {
            _account = account;
            _ItemTypesInBidHouse = new List<uint>();
            _ItemListInBidHouse = new List<uint>();

            _BidHouseDialogIsLoaded = false;
            _BidHouseItemTypeIsLoaded = false;
            _BidHouseItemQuantityPriceIsLoaded = false;
            _BidHouseItemMeanPriceIsLoaded = false;

            ItemPricesList = new List<List<ulong>>();
            MeanPrice = 0;

            account.Network.RegisterPacket<ExchangeStartedBidBuyerMessage>(HandleExchangeStartedBidBuyerMessage, MessagePriority.VeryHigh);
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

        public async Task<bool> StartBidHouseDialog()
        {
            /* Check if BidHouse Dialog is open */
            if (_BidHouseDialogIsLoaded) return true;

            /* Check if BidHouse Npc exists on current map */
            if (!BidHouseNpcOnMapExists())
            {
                _BidHouseDialogIsLoaded = false;
                _BidHouseItemTypeIsLoaded = false;
                _BidHouseItemQuantityPriceIsLoaded = false;
                _BidHouseItemMeanPriceIsLoaded = false;

                throw new Exception("Aucun PNJ d'hôtel de vente n'est présent sur cette map.");
            }

            /* Get Npc data */
            int NpcId = Convert.ToInt32(_account.Character.Map.Npcs.Find(npc => npc.Name.StartsWith("Vendeur ")).Id);
            string NpcName = _account.Character.Map.Npcs.Find(npc => npc.Name.StartsWith("Vendeur ")).Name;
            byte NpcActionId = (byte)6; /*TODO : Change 6 with its enum*/

            NpcGenericActionRequestMessage message = new NpcGenericActionRequestMessage()
            {
                NpcId = NpcId,
                NpcActionId = NpcActionId,
                NpcMapId = _account.Character.MapId
            };

            _account.Network.SendToServer(message);


            Logger.Default.Log($"Ouverture de la fenêtre HDV du PNJ {NpcName}({NpcId})", LogMessageType.Info);

            /* Wait for Bid House dialog to open */
            CancellationTokenSource Source = new CancellationTokenSource();
            Task t = Task.Run(() => { while (!_BidHouseDialogIsLoaded) { if (Source.IsCancellationRequested) break; } }, Source.Token);
            if (await Task.WhenAny(t, Task.Delay(3000, Source.Token)) == t) return true;

            Source.Cancel();

            throw new Exception("La fenêtre HDV n'a pas pu s'ouvrir.");

        }

        public void ExitBidHouseDialog()
        {
            _account.Network.SendToServer(new LeaveDialogRequestMessage());
        }

        public async Task<bool> LoadItemData(uint ItemId)
        {
            /* Init prices */
            ItemPricesList.Clear();
            MeanPrice = 0;

            /* Check if BidHouse Dialog is open */
            if (!_BidHouseDialogIsLoaded) throw new Exception("La fenêtre HDV n'est pas ouverte.");

            /* Request item type of itemid */
            if (!RequestItemType(ItemId)) return false;

            /* Check if item type is loaded */
            CancellationTokenSource Source = new CancellationTokenSource();
            Task CheckTypeTask = Task.Run(() => { while (!_BidHouseItemTypeIsLoaded) { if (Source.IsCancellationRequested) break; } }, Source.Token);
            if (await Task.WhenAny(CheckTypeTask, Task.Delay(3000, Source.Token)) != CheckTypeTask)
            {
                Source.Cancel();
                ExitBidHouseDialog();
                throw new Exception("La liste des items n'a pas pu s'ouvrir.");
            }

            /* We can now request item prices list*/
            RequestItemPrices(ItemId);

            /* Check if prices are loaded */
            Source = new CancellationTokenSource();
            Task CheckPriceTask = Task.Run(() => { while (!_BidHouseItemQuantityPriceIsLoaded || !_BidHouseItemMeanPriceIsLoaded) { if (Source.IsCancellationRequested) break; } }, Source.Token);
            if (await Task.WhenAny(CheckPriceTask, Task.Delay(3000, Source.Token)) == CheckPriceTask) return true;

            Source.Cancel();
            ExitBidHouseDialog();
            throw new Exception("La liste des prix de l'item n'a pas pu être chargée.");

        }

        #endregion

        #region "Private Functions"

        private bool RequestItemType(uint ItemId)
        {
            /* Check if item exists in Bid House */
            uint ItemType = ObjectDataManager.Instance.Get<API.Datacenter.Item>(ItemId).TypeId;
            if (!_ItemTypesInBidHouse.Contains(ItemType))
            {
                ExitBidHouseDialog();
                throw new Exception($"L'item {D2OParsing.GetItemName(ItemId)} ({ItemId}) n'existe pas dans cet hôtel de vente.");
            }

            ExchangeBidHouseTypeMessage ItemsTypeMessage = new ExchangeBidHouseTypeMessage()
            {
                Type = ItemType
            };

            _account.Network.SendToServer(ItemsTypeMessage);
            Logger.Default.Log($"Sélection de la catégorie {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<API.Datacenter.ItemType>(ItemType).NameId)} ({ItemType}).", LogMessageType.Info);

            return true;
        }

        private void RequestItemPrices(uint ItemId)
        {

            ExchangeBidHouseListMessage ItemsListMessage = new ExchangeBidHouseListMessage()
            {
                ObjectId = Convert.ToUInt16(ItemId)
            };
            _account.Network.SendToServer(ItemsListMessage);

            ExchangeBidHousePriceMessage ItemPriceMessage = new ExchangeBidHousePriceMessage()
            {
                GenId = Convert.ToUInt16(ItemId)
            };
            _account.Network.SendToServer(ItemPriceMessage);
        }

        #endregion

        #region TelegramsHandler

        private void HandleExchangeStartedBidBuyerMessage(IAccount account, ExchangeStartedBidBuyerMessage message)
        {
            _ItemTypesInBidHouse.Clear();
            _ItemTypesInBidHouse.AddRange(message.BuyerDescriptor.Types);

            _BidHouseDialogIsLoaded = true;

        }

        private void HandleExchangeTypesExchangerDescriptionForUserMessage(IAccount account, ExchangeTypesExchangerDescriptionForUserMessage message)
        {
            _ItemListInBidHouse.Clear();
            _ItemListInBidHouse.AddRange(message.TypeDescription);

            _BidHouseItemTypeIsLoaded = true;
        }

        private void HandleExchangeTypesItemsExchangerDescriptionForUserMessage(IAccount account, ExchangeTypesItemsExchangerDescriptionForUserMessage message)
        {
            ItemPricesList.Clear();
            message.ItemTypeDescriptions.ForEach(item => ItemPricesList.Add(item.Prices));

            _BidHouseItemQuantityPriceIsLoaded = true;

        }

        private void HandleExchangeBidPriceMessage(IAccount account, ExchangeBidPriceMessage message)
        {
            MeanPrice = message.AveragePrice;
            _BidHouseItemMeanPriceIsLoaded = true;
        }

        private void HandleExchangeLeaveMessage(IAccount account, ExchangeLeaveMessage message)
        {
            _BidHouseDialogIsLoaded = false;
            _BidHouseItemTypeIsLoaded = false;
            _BidHouseItemQuantityPriceIsLoaded = false;
            _BidHouseItemMeanPriceIsLoaded = false;
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