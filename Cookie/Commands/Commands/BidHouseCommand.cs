using System;
using System.Linq;
using System.Collections.Generic;

using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.Game.BidHouse;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class BidHouseCommand : ICommand
    {
        public string CommandName => "hdv";
        public string _commandSufix => "[HDV]";

        public async void OnCommand(IAccount account, string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    Logger.Default.Log("Vous devez spécifier l'id de l'item à chercher", LogMessageType.Error);
                }
                else
                {

                    uint itemid = Convert.ToUInt32(args[0]);

                    BidHouse Hdv = new BidHouse(account);
                    if (!await Hdv.StartBidHouseDialog()) return;
                    if (!await Hdv.LoadItemData(itemid)) return;

                    List<ulong> Prices = Hdv.ItemPricesList.FirstOrDefault();
                    Logger.Default.Log($" Prix de {API.Gamedata.D2OParsing.GetItemName(itemid)} => 1:{Prices[0]}-  10:{Prices[1]} - 100:{Prices[2]} - Mean:{Hdv.MeanPrice}");

                    Hdv.ExitBidHouseDialog();

                }
            }
            catch (Exception ex)
            {
                Logger.Default.Log($"{_commandSufix} Error : {ex.Message}", LogMessageType.Error);
                Logger.Default.Log($"{_commandSufix} StackTrace : {ex.StackTrace}", LogMessageType.Error);
            }

        }
    }
}
