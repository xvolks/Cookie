using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterStarRateBonus")]
    public class MonsterStarRateBonus : IDataObject
    {
		private const string MODULE = "MonsterStarRateBonus";
		public int Amount;
		public int Id;
		public List<int> CriterionsIds;
		public uint Type;
    }
}
