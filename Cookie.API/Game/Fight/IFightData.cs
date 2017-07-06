using Cookie.API.Game.Fight.Fighters;
using System.Collections.Generic;

namespace Cookie.API.Game.Fight
{
    public interface IFightData
    {
        /// <summary>
        ///     Liste des combattants
        /// </summary>
        List<IFighter> Fighters { get; }
        /// <summary>
        ///     Entité du bot
        /// </summary>
        IFighter Fighter { get; }
        /// <summary>
        ///     Id du fighter au moment du tour
        /// </summary>
        int TurnId { get; }
        /// <summary>
        ///     Récupère les cellules disponibles
        /// </summary>
        List<int> GetReachableCells();
        /// <summary>
        ///     Vérifie si le bot est main à main avec quelqu'un
        /// </summary>
        bool IsHandToHand();
        /// <summary>
        ///     Retourne le monstre le plus proche
        /// </summary>
        IMonster NearestMonster();
        /// <summary>
        ///     Retourne le monstre le plus faible
        /// </summary>
        IMonster WeakestMonster();
    }
}
