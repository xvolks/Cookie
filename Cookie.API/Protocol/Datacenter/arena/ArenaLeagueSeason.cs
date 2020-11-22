using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ArenaLeagueSeason")]
    public class ArenaLeagueSeason : IDataObject
    {
		private const string MODULE = "ArenaLeagueSeason";
		public int Id;
		public int NameId;
    }
}
