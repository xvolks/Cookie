using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AbuseReasons")]
    public class AbuseReasons : IDataObject
    {
		private const string MODULE = "AbuseReasons";
		public int AbuseReasonId;
		public int Mask;
		public int ReasonTextId;
    }
}
