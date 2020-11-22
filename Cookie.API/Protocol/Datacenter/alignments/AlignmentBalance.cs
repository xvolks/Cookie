using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentBalance")]
    public class AlignmentBalance : IDataObject
    {
		private const string MODULE = "AlignmentBalance";
		public int Id;
		public int StartValue;
		public int EndValue;
		public int NameId;
		public int DescriptionId;
    }
}
