using System;
using System.Collections.Generic;
using System.Threading;
using Cookie.API.Datacenter;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Protocol.Network.Messages;

namespace Cookie.API.Game.Fight
{
    public interface IFightData
    {
        /// <summary>
        ///     AutoResetEvent activates when spell was casted.
        /// </summary>
        AutoResetEvent SpellResetEvent { get; }
        /// <summary>
        ///     AutoResetEvent that sends a signal on MapMovement.
        /// </summary>
        AutoResetEvent MovementAutoReset { get; }
        /// <summary>
        ///     Resets in case a mob dies.
        /// </summary>
        AutoResetEvent FighterDiedAutoReset { get; }
        event EventHandler FightUpdate;
        /// <summary>
        ///     Current closeCombat weapon being held.
        /// </summary>
        Weapon Weapon { get; set; }
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
        bool IsHandToHand(int characterCellId = -1);

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
        SpellInabilityReason CanLaunchSpellOn(int spellId, int characterCellId, int cellId, bool withMove = false);
        List<IMonster> GetMonsters();
    }
}