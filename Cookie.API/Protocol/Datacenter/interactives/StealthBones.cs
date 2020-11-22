using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("StealthBones")]
    public class StealthBones : IDataObject
    {
		private const string MODULE = "StealthBones";
		public int Id;
    }
}
