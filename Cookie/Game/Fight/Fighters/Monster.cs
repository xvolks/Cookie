using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Gamedata;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;

namespace Cookie.Game.Fight.Fighters
{
    public class Monster : Fighter, IMonster
    {
        public Monster(int id, int cellId, GameFightMinimalStats stats, uint teamId, bool isAlive,
            ushort creatureGenericId, byte creatureGrade) : base(id, cellId, stats, teamId, isAlive)
        {
            CreatureGenericId = creatureGenericId;
            CreatureGrade = creatureGrade;
            Name = (string) D2OParsing.GetMonsterName(creatureGenericId);
        }

        public ushort CreatureGenericId { get; internal set; }
        public byte CreatureGrade { get; internal set; }
        public string Name { get; internal set; }
    }
}