using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Spirits")]
    public class Spirits : IDataObject
    {
		private const string MODULE = "Spirits";
		public int Id;
		public int Nameid;
		public int Characteristic;
		public List<uint> ItemIds;
    }
}
