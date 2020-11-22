using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Bonus")]
    public class Bonus : IDataObject
    {
		private const string MODULE = "Bonus";
		public int Id;
		public uint Type;
		public int Amount;
		public List<int> CriterionsIds;
    }
}
