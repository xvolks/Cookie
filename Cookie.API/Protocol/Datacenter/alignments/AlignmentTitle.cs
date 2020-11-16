using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentTitle")]
    public class AlignmentTitle : IDataObject
    {
		private const string MODULE = "AlignmentTitle";
		public int SideId;
		public List<int> NamesId;
		public List<int> ShortsId;
    }
}
