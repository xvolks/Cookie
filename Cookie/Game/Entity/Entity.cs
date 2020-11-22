using Cookie.API.Game.Entity;

namespace Cookie.Game.Entity
{
    public class Entity : IEntity
    {
        public Entity(double id, int cellId)
        {
            Id = id;
            CellId = cellId;
        }

        public int CellId { get; set; }
        public double Id { get; set; }
    }
}