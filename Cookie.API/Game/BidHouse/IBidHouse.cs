using System.Collections.Generic;
using System.Threading.Tasks;
using Cookie.API.Utils.Enums;

namespace Cookie.API.Game.BidHouse
{
    public interface IBidHouse
    {
        Dictionary<uint, List<ulong>> ItemPricesList { get; }
        long MeanPrice { get; }

        /// <summary>
        ///     Talks to Bid House NPC
        /// </summary>
        /// <param name="NpcActionId"></param>
        /// <returns></returns>
        Task<bool> StartBidHouseDialog(NpcActionId NpcActionId);

        void ExitBidHouseDialog();

        Task<bool> LoadItemData(uint itemId);

        Task<bool> SellItem(uint itemUId, int quantity, ulong price);

        Task<bool> BuyItem(uint itemUId, uint quantity);
    }
}