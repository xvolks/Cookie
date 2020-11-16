using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Waypoint")]
    public class Waypoint : IDataObject
    {
		private const string MODULE = "Waypoint";
		public int Id;
		public int MapId;
		public int SubAreaId;
		public bool Activated;
    }
}
