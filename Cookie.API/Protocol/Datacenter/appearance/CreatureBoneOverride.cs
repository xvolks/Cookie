using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CreatureBoneOverride")]
    public class CreatureBoneOverride : IDataObject
    {
		private const string MODULE = "CreatureBoneOverride";
		public int BoneId;
		public int CreatureBoneId;
    }
}
