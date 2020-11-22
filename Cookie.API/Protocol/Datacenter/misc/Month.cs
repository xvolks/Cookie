using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Month")]
    public class Month : IDataObject
    {
		private const string MODULE = "Month";
		public int Id;
		public int NameId;
    }
}
