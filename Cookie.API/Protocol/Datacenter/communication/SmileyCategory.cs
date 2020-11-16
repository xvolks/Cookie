using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SmileyCategory")]
    public class SmileyCategory : IDataObject
    {
		private const string MODULE = "SmileyCategory";
		public int Id;
		public int Order;
		public string GfxId;
		public bool IsFake;
    }
}
