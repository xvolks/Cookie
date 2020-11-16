using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MountBonus")]
    public class MountBonus : IDataObject
    {
		private const string MODULE = "MountBonus";
		public int Amount;
		public int Id;
		public List<int> CriterionsIds;
		public uint Type;
    }
}
