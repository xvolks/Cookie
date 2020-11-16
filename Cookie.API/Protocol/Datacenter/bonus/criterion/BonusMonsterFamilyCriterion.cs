using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusMonsterFamilyCriterion")]
    public class BonusMonsterFamilyCriterion : IDataObject
    {
		private const string MODULE = "BonusMonsterFamilyCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
