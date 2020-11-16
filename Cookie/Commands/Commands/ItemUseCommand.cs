using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Utils;
using System;

namespace Cookie.Commands.Commands
{
    public class ItemUseCommand : ICommand
    {
        public string CommandName => "itemUse";
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
            if (account.Character.Inventory.UseItem(itemId))
            {
                uint itemCount = account.Character.Inventory.ItemCount(itemId);
                Logger.Default.Log($"Item [{itemId}] was succefully used. {itemCount - 1} left.");
            }
            else
                Logger.Default.Log($"Could not use item [{itemId}].");
        }
    }
}
