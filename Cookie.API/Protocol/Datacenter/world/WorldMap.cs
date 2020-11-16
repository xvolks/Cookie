using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("WorldMap")]
    public class WorldMap : IDataObject
    {
		private const string MODULE = "WorldMap";
		public int Id;
		public int NameId;
		public int OrigineX;
		public int OrigineY;
		public double MapWidth;
		public double MapHeight;
		public bool ViewableEverywhere;
		public double MinScale;
		public double MaxScale;
		public double StartScale;
		public int TotalWidth;
		public int TotalHeight;
		public List<string> Zoom;
    }
}
