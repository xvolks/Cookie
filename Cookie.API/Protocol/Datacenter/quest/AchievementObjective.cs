using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AchievementObjective")]
    public class AchievementObjective : IDataObject
    {
		private const string MODULE = "AchievementObjective";
		public int Id;
		public int AchievementId;
		public int Order;
		public int NameId;
		public string Criterion;
    }
}
