using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Tips")]
    public class Tips : IDataObject
    {
		private const string MODULE = "Tips";
		public int Id;
		public int DescId;
    }
}
