using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("OptionalFeature")]
    public class OptionalFeature : IDataObject
    {
		private const string MODULE = "OptionalFeature";
		public int Id;
		public string Keyword;
    }
}
