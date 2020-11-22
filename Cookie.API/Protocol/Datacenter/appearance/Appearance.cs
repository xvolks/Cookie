using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Appearance")]
    public class Appearance : IDataObject
    {
		private const string MODULE = "Appearance";
		public int Id;
		public int Type;
		public string Data;
    }
}
