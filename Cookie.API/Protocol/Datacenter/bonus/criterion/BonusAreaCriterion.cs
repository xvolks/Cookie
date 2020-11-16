using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusAreaCriterion")]
    public class BonusAreaCriterion : IDataObject
    {
		private const string MODULE = "BonusAreaCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
