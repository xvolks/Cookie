using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MountBone")]
    public class MountBone : IDataObject
    {
		private const string MODULE = "MountBone";
		public int Id;
    }
}
