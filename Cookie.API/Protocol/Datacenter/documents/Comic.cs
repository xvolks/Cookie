using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Comic")]
    public class Comic : IDataObject
    {
		private const string MODULE = "Comic";
		public int Id;
		public string RemoteId;
    }
}
