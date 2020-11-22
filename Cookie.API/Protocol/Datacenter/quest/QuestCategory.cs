using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestCategory")]
    public class QuestCategory : IDataObject
    {
		private const string MODULE = "QuestCategory";
		public int Id;
		public int NameId;
		public int Order;
		public List<uint> QuestIds;
    }
}
