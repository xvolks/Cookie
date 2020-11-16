using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentSide")]
    public class AlignmentSide : IDataObject
    {
		private const string MODULE = "AlignmentSide";
		public int Id;
		public int NameId;
		public bool CanConquest;
    }
}
