using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("PointOfInterest")]
    public class PointOfInterest : IDataObject
    {
		private const string MODULE = "PointOfInterest";
		public int Id;
		public int NameId;
		public int CategoryId;
    }
}
