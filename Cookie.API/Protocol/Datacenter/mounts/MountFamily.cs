using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MountFamily")]
    public class MountFamily : IDataObject
    {
		private const string MODULE = "MountFamily";
		public int Id;
		public int NameId;
		public string HeadUri;
    }
}
