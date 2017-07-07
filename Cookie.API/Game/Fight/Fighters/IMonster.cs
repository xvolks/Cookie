namespace Cookie.API.Game.Fight.Fighters
{
    public interface IMonster : IFighter
    {
        /// <summary>
        ///     Id du monstre
        /// </summary>
        ushort CreatureGenericId { get; }

        /// <summary>
        ///     Données du grade de la créature
        /// </summary>
        byte CreatureGrade { get; }

        /// <summary>
        ///     Nom du monstre
        /// </summary>
        string Name { get; }
    }
}