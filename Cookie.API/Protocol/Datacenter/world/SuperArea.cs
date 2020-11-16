using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SuperArea")]
    public class SuperArea : IDataObject
    {
		private const string MODULE = "SuperArea";
		public int Id;
		public int NameId;
		public int WorldmapId;
		public bool HasWorldMap;
    }
}
