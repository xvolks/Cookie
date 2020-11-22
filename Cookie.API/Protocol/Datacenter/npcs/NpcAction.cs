using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("NpcAction")]
    public class NpcAction : IDataObject
    {
		private const string MODULE = "NpcAction";
		public int Id;
		public int RealId;
		public int NameId;
    }
}
