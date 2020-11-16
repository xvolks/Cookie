using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CreatureBoneType")]
    public class CreatureBoneType : IDataObject
    {
		private const string MODULE = "CreatureBoneType";
		public int Id;
		public int CreatureBoneId;
    }
}
