using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestObjectiveDiscoverMap")]
    public class QuestObjectiveDiscoverMap : IDataObject
    {
		private const string MODULE = "QuestObjectiveDiscoverMap";
		public int StepId;
		public int TypeId;
		public int MapId;
		public int Id;
		public int DialogId;
		public QuestObjectiveParameters Parameters;
		public Point Coords;
    }
}
