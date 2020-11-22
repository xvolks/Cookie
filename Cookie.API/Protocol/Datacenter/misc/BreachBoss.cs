using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BreachBoss")]
    public class BreachBoss : IDataObject
    {
		private const string MODULE = "BreachBoss";
		public int Id;
		public int MonsterId;
		public int Category;
		public string ApparitionCriterion;
		public string AccessCriterion;
		public int MaxRewardQuantity;
		public List<int> IncompatibleBosses;
		public uint RewardId;
    }
}
