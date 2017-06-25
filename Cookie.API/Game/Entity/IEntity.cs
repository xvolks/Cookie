namespace Cookie.API.Game.Entity
{
    public interface IEntity
    {
        /// <summary>Cellule de l'entité</summary>
        int CellId { get; }

        /// <summary>Identifiant de l'entité</summary>
        int Id { get; }
    }
}