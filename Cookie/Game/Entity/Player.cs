using Cookie.API.Game.Entity;

namespace Cookie.Game.Entity
{
    public class Player : IPlayer, IEntity
    {
        public Player(int cell, double id, string name)
        {
            CellId = cell;
            Id = id;
            Name = name;
        }

        public int CellId { get; set; }

        public double Id { get; set; }

        public string Name { get; set; }
    }
}