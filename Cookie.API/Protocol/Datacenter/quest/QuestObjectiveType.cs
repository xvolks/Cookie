using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestObjectiveType")]
    public class QuestObjectiveType : IDataObject
    {
		private const string MODULE = "QuestObjectiveType";
		public int Id;
		public int NameId;
    }
}
