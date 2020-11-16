using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AchievementReward")]
    public class AchievementReward : IDataObject
    {
		private const string MODULE = "AchievementReward";
		public int Id;
		public int AchievementId;
		public string Criteria;
		public double KamasRatio;
		public double ExperienceRatio;
		public bool KamasScaleWithPlayerLevel;
		public List<uint> ItemsReward;
		public List<uint> ItemsQuantityReward;
		public List<uint> EmotesReward;
		public List<uint> SpellsReward;
		public List<uint> TitlesReward;
		public List<uint> OrnamentsReward;
    }
}
