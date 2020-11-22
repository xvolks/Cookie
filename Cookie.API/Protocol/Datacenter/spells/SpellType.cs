using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellType")]
    public class SpellType : IDataObject
    {
		private const string MODULE = "SpellType";
		public int Id;
		public int LongNameId;
		public int ShortNameId;
    }
}
