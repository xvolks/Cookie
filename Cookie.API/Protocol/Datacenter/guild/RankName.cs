using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("RankName")]
    public class RankName : IDataObject
    {
		private const string MODULE = "RankName";
		public int Id;
		public int NameId;
		public int Order;
    }
}
