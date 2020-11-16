using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterSuperRace")]
    public class MonsterSuperRace : IDataObject
    {
		private const string MODULE = "MonsterSuperRace";
		public int Id;
		public int NameId;
    }
}
