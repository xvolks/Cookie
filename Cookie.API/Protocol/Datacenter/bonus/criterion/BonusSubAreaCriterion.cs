using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusSubAreaCriterion")]
    public class BonusSubAreaCriterion : IDataObject
    {
		private const string MODULE = "BonusSubAreaCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
