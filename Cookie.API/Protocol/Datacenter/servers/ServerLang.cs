using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerLang")]
    public class ServerLang : IDataObject
    {
		private const string MODULE = "ServerLang";
		public int Id;
		public int NameId;
		public string LangCode;
    }
}
