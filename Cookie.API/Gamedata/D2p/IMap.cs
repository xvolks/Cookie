using System.Collections.Generic;

namespace Cookie.API.Gamedata.D2p
{
    /// <summary>
    ///     Represents some extra data of the current map
    /// </summary>
    public interface IMap
    {
        /// <summary>
        ///     Gets the list of cells in the current map
        /// </summary>
        List<CellData> Cells { get; }

        /// <summary>
        ///     Gets the cells count in the current map
        /// </summary>
        int CellsCount { get; }

        /// <summary>
        ///     Looks if a cell is in line of sight
        /// </summary>
        /// <param name="cellId">The cell's id</param>
        /// <returns>True if the cell is in line of sight</returns>
        bool IsLineOfSight(int cellId);

        /// <summary>
        ///     Looks if a cell is walkable
        /// </summary>
        /// <param name="cellId">The cell's id</param>
        /// <returns>True if the cell is walkable</returns>
        bool IsWalkable(int cellId);
    }
}