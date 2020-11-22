using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapScrollAction")]
    public class MapScrollAction : IDataObject
    {
		private const string MODULE = "MapScrollAction";
		public double Id;
		public bool RightExists;
		public bool BottomExists;
		public bool LeftExists;
		public bool TopExists;
		public double RightMapId;
		public double BottomMapId;
		public double LeftMapId;
		public double TopMapId;
    }
}
