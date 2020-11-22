using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestStepRewards")]
    public class QuestStepRewards : IDataObject
    {
		private const string MODULE = "QuestStepRewards";
		public int Id;
		public int StepId;
		public int LevelMin;
		public int LevelMax;
		public double KamasRatio;
		public double ExperienceRatio;
		public bool KamasScaleWithPlayerLevel;
		public List<List<uint>> ItemsReward;
		public List<uint> EmotesReward;
		public List<uint> JobsReward;
		public List<uint> SpellsReward;
		public List<uint> TitlesReward;
    }
}
