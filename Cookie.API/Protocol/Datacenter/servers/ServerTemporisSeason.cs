using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerTemporisSeason")]
    public class ServerTemporisSeason : IDataObject
    {
		private const string MODULE = "ServerTemporisSeason";
		public int Uid;
		public int SeasonNumber;
		public string Information;
		public double Beginning;
		public double Closure;
    }
}
