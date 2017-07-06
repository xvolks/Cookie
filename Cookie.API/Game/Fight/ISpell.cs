namespace Cookie.API.Game.Fight
{
    public interface ISpell
    {
        /// <summary>
        ///     Id du sort
        /// </summary>
        int Id { get; }
        /// <summary>
        ///     Niveau du sort
        /// </summary>
        int Level { get; }
        /// <summary>
        ///     Position du sort
        /// </summary>
        int Position { get; }
        /// <summary>
        ///     Nom du sort
        /// </summary>
        string Name { get; }
    }
}
