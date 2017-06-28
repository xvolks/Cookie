using System;

namespace Cookie.API.Game.Map
{
    public interface IMapChangement
    {
        /// <summary>
        ///     Gets the new map's id
        /// </summary>
        int NewMap { get; }

        /// <summary>
        ///     Performs the map changement (An IMapChangement is useless if you don't call this method)
        /// </summary>
        void PerformChangement();

        /// <summary>
        ///     Triggers when the changement has ended (either failed or succeeded)
        /// </summary>
        event EventHandler<MapChangementFinishedEventArgs> ChangementFinished;

        /// <summary>
        ///     Tries when the map changement times out
        /// </summary>
        event Action Timeout;
    }
}