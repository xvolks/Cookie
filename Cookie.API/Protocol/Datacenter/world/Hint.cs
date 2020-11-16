using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Hint")]
    public class Hint : IDataObject
    {
		private const string MODULE = "Hint";
		public int Id;
		public int CategoryId;
		public int Gfx;
		public int NameId;
		public int MapId;
		public int RealMapId;
		public int X;
		public int Y;
		public bool Outdoor;
		public int SubareaId;
		public int WorldMapId;
		public uint Level;
    }
}
