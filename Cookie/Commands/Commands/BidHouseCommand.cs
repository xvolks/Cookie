using System;
using System.Linq;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class BidHouseCommand : ICommand
    {
        public string CommandSufix => "[HDV]";
        public string CommandName => "hdv";
        public string ArgsName => "string [list|exit|price|sell|buy], (uint <itemId>)";

        public async void OnCommand(IAccount account, string[] args)
        {
            try
            {
                if (args.Length < 1 || (args[0] == "list" || args[0] == "exit") && args.Length < 2)
                {
                    Logger.Default.Log("Vous devez spécifier l'id de l'item à chercher", LogMessageType.Error);
                }
                else if (args[0] == "list")
                {
                    account.Character.Inventory.Objects.ForEach(item =>
                        Logger.Default.Log(
                            $"{item.Quantity}x{D2OParsing.GetItemName(item.ObjectGID)} ({item.ObjectGID}, {item.ObjectUID})"));
                }
                else if (args[0] == "exit")
                {
                    account.Character.BidHouse.ExitBidHouseDialog();
                }
                else if (args[0] == "price")
                {
                    var itemId = Convert.ToUInt32(args[1]);

                    if (!await account.Character.BidHouse.StartBidHouseDialog(NpcActionId.BID_HOUSE_BUY)) return;
                    if (!await account.Character.BidHouse.LoadItemData(itemId)) return;

                    var prices = account.Character.BidHouse.ItemPricesList.FirstOrDefault();
                    Logger.Default.Log(
                        $" Prix de {D2OParsing.GetItemName(itemId)} ({itemId}, {prices.Key}) => (1:{prices.Value[0]}k 10:{prices.Value[1]}k 100:{prices.Value[2]}k) - ~{account.Character.BidHouse.MeanPrice}k");
                }
                else if (args[0] == "sell")
                {
                    var itemId = Convert.ToUInt32(args[1]);
                    var quantity = Convert.ToInt32(args[2]);
                    var price = Convert.ToUInt32(args[3]);

                    if (!await account.Character.BidHouse.StartBidHouseDialog(NpcActionId.BID_HOUSE_SELL)) return;

                    if (!await account.Character.BidHouse.SellItem(itemId, quantity, price)) return;
                }
                else if (args[0] == "buy")
                {
                    var itemUid = Convert.ToUInt32(args[1]);
                    var quantity = Convert.ToUInt32(args[2]);

                    if (!await account.Character.BidHouse.StartBidHouseDialog(NpcActionId.BID_HOUSE_BUY)) return;

                    if (!await account.Character.BidHouse.BuyItem(itemUid, quantity)) return;
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Log($"{CommandSufix} Error : {ex.Message}", LogMessageType.Error);
                Logger.Default.Log($"{CommandSufix} StackTrace : {ex.StackTrace}", LogMessageType.Error);
            }
        }
    }
}