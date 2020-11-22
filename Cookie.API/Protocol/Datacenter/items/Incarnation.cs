using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Incarnation")]
    public class Incarnation : IDataObject
    {
		private const string MODULE = "Incarnation";
		public int Id;
		public string LookMale;
		public string LookFemale;
    }
}
