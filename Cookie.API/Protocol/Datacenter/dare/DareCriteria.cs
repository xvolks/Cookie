using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("DareCriteria")]
    public class DareCriteria : IDataObject
    {
		private const string MODULE = "DareCriteria";
		public int Id;
		public int NameId;
		public uint MaxOccurence;
		public uint MaxParameters;
		public int MinParameterBound;
		public int MaxParameterBound;
    }
}
