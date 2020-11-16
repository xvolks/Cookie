using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("TitleCategory")]
    public class TitleCategory : IDataObject
    {
		private const string MODULE = "TitleCategory";
		public int Id;
		public int NameId;
    }
}
