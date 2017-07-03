using Cookie.API.Game.Entity;

namespace Cookie.Game.Entity
{
    public class Player : IPlayer, IEntity
    {
        public int CellId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Player(int cell, int id, string name)
        {
            CellId = cell;
            Id = id;
            Name = name;
        }
    }
}