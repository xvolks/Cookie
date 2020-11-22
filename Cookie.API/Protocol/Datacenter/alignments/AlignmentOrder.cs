using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentOrder")]
    public class AlignmentOrder : IDataObject
    {
		private const string MODULE = "AlignmentOrder";
		public int Id;
		public int NameId;
		public int SideId;
    }
}
