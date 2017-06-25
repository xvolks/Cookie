namespace Cookie.API.Game.Map
{
    public interface IMapData
    {
        /// <summary>Indique si la case spécifiée possède l'attribut 'ligne de vue'</summary>
        /// <param name="cellId">Identifiant de la cellule</param>
        /// <returns>True si la cellule est visible, sinon False</returns>
        bool IsLineOfSight(int cellId);

        /// <summary>Indique si la case spécifiée possède l'attribut 'marchable'</summary>
        /// <param name="cellId">Identifiant de la cellule</param>
        /// <returns>True si la cellule est marchable, sinon False</returns>
        bool IsWalkable(int cellId);
    }
}