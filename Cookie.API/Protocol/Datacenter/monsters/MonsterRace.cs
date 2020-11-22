using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterRace")]
    public class MonsterRace : IDataObject
    {
		private const string MODULE = "MonsterRace";
		public int Id;
		public int SuperRaceId;
		public int NameId;
		public int AggressiveZoneSize;
		public int AggressiveLevelDiff;
		public string AggressiveImmunityCriterion;
		public int AggressiveAttackDelay;
		public List<uint> Monsters;
    }
}
