using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestObjectiveParameters")]
    public class QuestObjectiveParameters : IDataObject
    {
		private const string MODULE = "QuestObjectiveParameters";
		public uint NumParams;
		public int Parameter0;
		public int Parameter1;
		public int Parameter2;
		public int Parameter3;
		public int Parameter4;
		public bool DungeonOnly;
    }
}
