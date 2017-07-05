using Cookie.API.Game.Entity;
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

        public uint LifePoints { get; internal set; }
        public uint MaxLifePoints { get; internal set; }
        public short ActionPoints { get; internal set; }
        public short MovementPoints { get; internal set; }
        public bool IsAlive { get; internal set; }
        public uint TeamId { get; internal set; }
        public GameFightMinimalStats Stats { get; internal set; }
    }
}