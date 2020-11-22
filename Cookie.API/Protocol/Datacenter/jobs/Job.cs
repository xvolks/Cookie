using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Job")]
    public class Job : IDataObject
    {
		private const string MODULE = "Job";
		public int Id;
		public int NameId;
		public int IconId;
    }
}
