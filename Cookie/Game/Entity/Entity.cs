using Cookie.API.Game.Entity;

namespace Cookie.Game.Entity
{
    public class Entity : IEntity
    {
        public Entity(int id, int cellId)
        {
            Id = id;
            CellId = cellId;
        }

        public int CellId { get; internal set; }
        public int Id { get; protected set; }
    }
}