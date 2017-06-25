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
    }
}