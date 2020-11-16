using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ArenaLeague")]
    public class ArenaLeague : IDataObject
    {
		private const string MODULE = "ArenaLeague";
		public int Id;
		public int NameId;
		public int OrnamentId;
		public string Icon;
		public string Illus;
		public bool IsLastLeague;
    }
}
