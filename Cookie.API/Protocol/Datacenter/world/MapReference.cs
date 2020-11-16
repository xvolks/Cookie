using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapReference")]
    public class MapReference : IDataObject
    {
		private const string MODULE = "MapReference";
		public int Id;
		public int MapId;
		public int CellId;
    }
}
