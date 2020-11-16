using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestObjectiveDiscoverSubArea")]
    public class QuestObjectiveDiscoverSubArea : IDataObject
    {
		private const string MODULE = "QuestObjectiveDiscoverSubArea";
		public int StepId;
		public int TypeId;
		public int MapId;
		public int Id;
		public int DialogId;
		public QuestObjectiveParameters Parameters;
		public Point Coords;
    }
}
