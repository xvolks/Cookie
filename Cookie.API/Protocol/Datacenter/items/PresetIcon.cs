using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("PresetIcon")]
    public class PresetIcon : IDataObject
    {
		private const string MODULE = "PresetIcon";
		public int Id;
		public int Order;
    }
}
