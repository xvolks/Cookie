namespace Cookie.API.Game.Map.Elements
{
    public interface IStatedElement
    {
        /// <summary>Cellule de l'élément</summary>
        uint CellId { get; }

        /// <summary>Identifiant de cet élément</summary>
        uint Id { get; }

        uint State { get; }
    }
}