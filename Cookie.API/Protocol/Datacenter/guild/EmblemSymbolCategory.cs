using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EmblemSymbolCategory")]
    public class EmblemSymbolCategory : IDataObject
    {
		private const string MODULE = "EmblemSymbolCategory";
		public int Id;
		public int NameId;
    }
}
