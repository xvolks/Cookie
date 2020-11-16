using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("IdolsPresetIcon")]
    public class IdolsPresetIcon : IDataObject
    {
		private const string MODULE = "IdolsPresetIcon";
		public int Id;
		public int Order;
    }
}
