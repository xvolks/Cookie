using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestStep")]
    public class QuestStep : IDataObject
    {
		private const string MODULE = "QuestStep";
		public int Id;
		public int QuestId;
		public int NameId;
		public int DescriptionId;
		public int DialogId;
		public int OptimalLevel;
		public double Duration;
		public List<uint> ObjectiveIds;
		public List<uint> RewardsIds;
    }
}
