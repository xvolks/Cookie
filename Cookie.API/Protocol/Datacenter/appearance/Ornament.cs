using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Ornament")]
    public class Ornament : IDataObject
    {
		private const string MODULE = "Ornament";
		public int Id;
		public int NameId;
		public bool Visible;
		public int AssetId;
		public int IconId;
		public int Rarity;
		public int Order;
    }
}
