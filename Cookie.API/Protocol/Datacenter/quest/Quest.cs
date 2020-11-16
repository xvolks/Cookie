using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Quest")]
    public class Quest : IDataObject
    {
		private const string MODULE = "Quest";
		public int Id;
		public int NameId;
		public int CategoryId;
		public int RepeatType;
		public int RepeatLimit;
		public bool IsDungeonQuest;
		public int LevelMin;
		public int LevelMax;
		public List<uint> StepIds;
		public bool IsPartyQuest;
		public string StartCriterion;
		public bool Followable;
    }
}
