using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MountBehavior")]
    public class MountBehavior : IDataObject
    {
		private const string MODULE = "MountBehavior";
		public int Id;
		public int NameId;
		public int DescriptionId;
    }
}
