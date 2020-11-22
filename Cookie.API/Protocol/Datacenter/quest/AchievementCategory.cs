using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AchievementCategory")]
    public class AchievementCategory : IDataObject
    {
		private const string MODULE = "AchievementCategory";
		public int Id;
		public int NameId;
		public int ParentId;
		public string Icon;
		public int Order;
		public string Color;
		public List<uint> AchievementIds;
		public string VisibilityCriterion;
    }
}
