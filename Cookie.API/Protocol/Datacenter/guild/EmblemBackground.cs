using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EmblemBackground")]
    public class EmblemBackground : IDataObject
    {
		private const string MODULE = "EmblemBackground";
		public int Id;
		public int Order;
    }
}
