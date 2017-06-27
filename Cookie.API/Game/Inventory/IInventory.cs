using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;

namespace Cookie.API.Game.Inventory
{
    public interface IInventory
    {
        List<ObjectItem> Objects { get; set; }
    }
}