using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Area")]
    public class Area : IDataObject
    {
		private const string MODULE = "Area";
		public int Id;
		public int NameId;
		public int SuperAreaId;
		public bool ContainHouses;
		public bool ContainPaddocks;
		public Rectangle Bounds;
		public int WorldmapId;
		public bool HasWorldMap;
    }
}
