using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("TaxCollectorName")]
    public class TaxCollectorName : IDataObject
    {
		private const string MODULE = "TaxCollectorName";
		public int Id;
		public int NameId;
    }
}
