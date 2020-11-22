using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.Commands.Commands
{
    public class ItemListCommand : ICommand
    {
        public string CommandName => "itemList";
        public string ArgsName => "void";

        public void OnCommand(IAccount account, string[] args)
        {
            string itemName = "";
            foreach (var item in account.Character.Inventory.Objects)
            {
                try
                {
                    itemName = FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Cookie.API.Datacenter.Item>(item.ObjectGID).NameId);

                }
                catch (Exception)
                {

                }
                Logger.Default.Log($"Name[{itemName}] ItemId[{item.ObjectGID}] Quantity[{item.Quantity}]");
            }
        }
    }
}
