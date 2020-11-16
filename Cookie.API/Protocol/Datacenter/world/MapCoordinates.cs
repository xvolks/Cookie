using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapCoordinates")]
    public class MapCoordinates : IDataObject
    {
		private const string MODULE = "MapCoordinates";
		public int CompressedCoords;
		public List<double> MapIds;
    }
}
