using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("HavenbagFurniture")]
    public class HavenbagFurniture : IDataObject
    {
		private const string MODULE = "HavenbagFurniture";
		public int TypeId;
		public int ThemeId;
		public int ElementId;
		public int Color;
		public int SkillId;
		public int LayerId;
		public bool BlocksMovement;
		public bool IsStackable;
		public uint CellsWidth;
		public uint CellsHeight;
		public uint Order;
    }
}
