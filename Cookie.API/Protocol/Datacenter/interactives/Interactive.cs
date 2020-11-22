using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Interactive")]
    public class Interactive : IDataObject
    {
		private const string MODULE = "Interactive";
		public int Id;
		public int NameId;
		public int ActionId;
		public bool DisplayTooltip;
    }
}
