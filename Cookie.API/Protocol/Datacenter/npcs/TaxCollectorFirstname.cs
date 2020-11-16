using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("TaxCollectorFirstname")]
    public class TaxCollectorFirstname : IDataObject
    {
		private const string MODULE = "TaxCollectorFirstname";
		public int Id;
		public int FirstnameId;
    }
}
