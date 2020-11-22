using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestObjective")]
    public class QuestObjective : IDataObject
    {
		private const string MODULE = "QuestObjective";
		public int Id;
		public int StepId;
		public int TypeId;
		public int DialogId;
		public QuestObjectiveParameters Parameters;
		public Point Coords;
		public int MapId;
    }
}
