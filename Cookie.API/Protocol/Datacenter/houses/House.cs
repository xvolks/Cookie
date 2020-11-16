using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("House")]
    public class House : IDataObject
    {
		private const string MODULE = "House";
		public int TypeId;
		public int DefaultPrice;
		public int NameId;
		public int DescriptionId;
		public int GfxId;
    }
}
