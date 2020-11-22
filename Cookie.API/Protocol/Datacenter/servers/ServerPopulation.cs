using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerPopulation")]
    public class ServerPopulation : IDataObject
    {
		private const string MODULE = "ServerPopulation";
		public int Id;
		public int NameId;
		public int Weight;
    }
}
