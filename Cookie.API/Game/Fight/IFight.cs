using System;
using Cookie.API.Game.Map;
using Cookie.API.Protocol.Network.Messages;

namespace Cookie.API.Game.Fight
{
    public interface IFight : IFightData
    {
        /// <summary>
        ///     Fin du tour
        /// </summary>
        void EndTurn();

        /// <summary>
        ///     Envoie prêt au serveur
        /// </summary>
        void SetReady();

        /// <summary>
        ///     Fermeture du combat
        /// </summary>
        void LockFight();

        /// <summary>
        ///     Hide combat
        /// </summary> 
        void LockObserver();

        /// <summary>
        ///     Only allow Party Members to join the fight
        /// </summary>
        void LockPartyOnly();

        /// <summary>
        ///     Kick un joueur
        /// </summary>
        void KickPlayer(int id);

        /// <summary>
        ///     Aller à une cellule
        /// </summary>
        ICellMovement MoveToCell(int cellId);
        event Action<GameActionFightSpellCastMessage> SpellCasted;
        event Action<GameActionFightCloseCombatMessage> CloseCombatCasted;
        SpellInabilityReason CanLaunchSpell(int spellId);
    }
}