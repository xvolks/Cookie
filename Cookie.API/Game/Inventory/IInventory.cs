using System.Collections.Generic;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Game.Inventory
{
    public interface IInventory
    {
        List<ObjectItem> Objects { get; set; }
        Dictionary<CharacterInventoryPositionEnum, ObjectItem> Equipment { get; set; }
        bool UseItem(int itemId);
        bool HasItem(int itemId);
        uint ItemCount(int itemId);
    }
}