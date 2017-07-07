namespace Cookie.API.Game.Fight
{
    public interface IFight : IFightData
    {
        /// <summary>
        ///     Lance un sort
        /// </summary>
        void LaunchSpell(int spellId, int cellId);

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
        ///     Kick un joueur
        /// </summary>
        void KickPlayer(int id);

        /// <summary>
        ///     Aller à une cellule
        /// </summary>
        bool MoveToCell(int cellId);
    }
}