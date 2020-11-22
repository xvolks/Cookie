using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("NamingRule")]
    public class NamingRule : IDataObject
    {
		private const string MODULE = "NamingRule";
		public int Id;
		public int MinLength;
		public int MaxLength;
		public string Regexp;
    }
}
