using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.Commands.Commands
{
    public class ItemCountCommand : ICommand
    {
        public string CommandName => "itemCount";
        public string ArgsName => "itemId";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log($"You have to specify the itemId that will be used... '.{CommandName} {ArgsName}'");
                return;
            }
            int itemId = Convert.ToInt32(args[0]);
            if (itemId == 0)
            {
                Logger.Default.Log($"ItemId is not valid.");
            }
            uint itemCount = account.Character.Inventory.ItemCount(itemId);
            Logger.Default.Log($"{itemCount} were found of {itemId}.");
        }
    }
}
