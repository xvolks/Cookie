using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Characteristic")]
    public class Characteristic : IDataObject
    {
		private const string MODULE = "Characteristic";
		public int Id;
		public string Keyword;
		public int NameId;
		public string Asset;
		public int CategoryId;
		public bool Visible;
		public int Order;
		public bool Upgradable;
    }
}
