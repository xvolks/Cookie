namespace Cookie.API.Game.Entity
{
    public interface IEntity
    {
        /// <summary>
        ///     Cellule de l'entité
        /// </summary>
        int CellId { get; set; }

        /// <summary>
        ///     Identifiant de l'entité
        /// </summary>
        double Id { get; set; }
    }
}