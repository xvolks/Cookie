using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentRank")]
    public class AlignmentRank : IDataObject
    {
		private const string MODULE = "AlignmentRank";
		public int Id;
		public int OrderId;
		public int NameId;
		public int DescriptionId;
		public int MinimumAlignment;
		public int ObjectsStolen;
		public List<int> Gifts;
    }
}
