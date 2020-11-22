using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Url")]
    public class Url : IDataObject
    {
		private const string MODULE = "Url";
		public int Id;
		public int BrowserId;
		public string url;
		public string Param;
		public string Method;
    }
}
