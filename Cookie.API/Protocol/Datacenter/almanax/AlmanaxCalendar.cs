using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlmanaxCalendar")]
    public class AlmanaxCalendar : IDataObject
    {
		private const string MODULE = "AlmanaxCalendar";
		public int Id;
		public int NameId;
		public int DescId;
		public int NpcId;
		public List<int> BonusesIds;
    }
}
