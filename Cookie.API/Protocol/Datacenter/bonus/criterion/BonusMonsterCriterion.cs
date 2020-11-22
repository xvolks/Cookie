using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusMonsterCriterion")]
    public class BonusMonsterCriterion : IDataObject
    {
		private const string MODULE = "BonusMonsterCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
