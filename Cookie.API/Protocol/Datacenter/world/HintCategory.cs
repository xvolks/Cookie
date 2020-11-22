using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("HintCategory")]
    public class HintCategory : IDataObject
    {
		private const string MODULE = "HintCategory";
		public int Id;
		public int NameId;
    }
}
