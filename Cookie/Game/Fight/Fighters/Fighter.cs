using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;

namespace Cookie.Game.Fight.Fighters
{
    public class Fighter : Entity.Entity, IFighter
    {
        public Fighter(double id, int cellId, GameFightMinimalStats stats, uint teamId, bool isAlive) : base(id, cellId)
        {
            Stats = stats;
            TeamId = teamId;
            IsAlive = isAlive;
            LifePoints = stats.LifePoints;
            MaxLifePoints = stats.MaxLifePoints;
            ActionPoints = stats.ActionPoints;
            MovementPoints = stats.MovementPoints;
        }

        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public short ActionPoints { get; set; }
        public short MovementPoints { get; set; }
        public bool IsAlive { get; set; }
        public uint TeamId { get; set; }
        public GameFightMinimalStats Stats { get; set; }
    }
}