using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterMiniBoss")]
    public class MonsterMiniBoss : IDataObject
    {
		private const string MODULE = "MonsterMiniBoss";
		public int Id;
		public int MonsterReplacingId;
    }
}
