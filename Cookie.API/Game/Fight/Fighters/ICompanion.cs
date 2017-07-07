namespace Cookie.API.Game.Fight.Fighters
{
    public interface ICompanion : IFighter
    {
        /// <summary>
        ///     Niveau du compagnon
        /// </summary>
        int Level { get; }

        /// <summary>
        ///     Id du compagnon
        /// </summary>
        byte CompanionGenericId { get; }

        /// <summary>
        ///     Nom du monstre
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Id du propriétaire
        /// </summary>
        double MasterId { get; }
    }
}