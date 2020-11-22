using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("FinishMove")]
    public class FinishMove : IDataObject
    {
		private const string MODULE = "FinishMove";
		public int Id;
		public int Duration;
		public bool Free;
		public int NameId;
		public int Category;
		public int SpellLevel;
    }
}
