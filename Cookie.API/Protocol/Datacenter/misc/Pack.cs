using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Pack")]
    public class Pack : IDataObject
    {
		private const string MODULE = "Pack";
		public int Id;
		public string Name;
		public bool HasSubAreas;
    }
}
