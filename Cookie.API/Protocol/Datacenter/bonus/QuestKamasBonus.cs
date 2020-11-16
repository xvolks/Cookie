using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestKamasBonus")]
    public class QuestKamasBonus : IDataObject
    {
		private const string MODULE = "QuestKamasBonus";
		public int Amount;
		public int Id;
		public List<int> CriterionsIds;
		public uint Type;
    }
}
