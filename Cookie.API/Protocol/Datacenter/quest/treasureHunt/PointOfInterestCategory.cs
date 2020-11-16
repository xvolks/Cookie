using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("PointOfInterestCategory")]
    public class PointOfInterestCategory : IDataObject
    {
		private const string MODULE = "PointOfInterestCategory";
		public int Id;
		public int ActionLabelId;
    }
}
