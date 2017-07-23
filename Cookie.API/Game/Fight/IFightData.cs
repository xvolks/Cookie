using System;
using System.Collections.Generic;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;

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
        ///     Indique dès que le combat démarre
        /// </summary>
        event Action FightStarted;

        /// <summary>
        ///     Indique dès que c'est le tour du bot
        /// </summary>
        event Action TurnStarted;

        /// <summary>
        ///     Indique dès que le combat fini
        /// </summary>
        event Action<GameFightEndMessage> FightEnded;

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

        /// <summary>
        ///     Test si le sort peut être utiliser
        /// </summary>
        int CanUseSpell(int spellId, IFighter target);

        List<IMonster> GetMonsters();
    }
}