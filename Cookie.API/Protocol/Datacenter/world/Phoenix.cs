using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Phoenix")]
    public class Phoenix : IDataObject
    {
		private const string MODULE = "Phoenix";
		public int MapId;
    }
}
