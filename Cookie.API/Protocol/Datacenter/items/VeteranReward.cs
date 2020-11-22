using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("VeteranReward")]
    public class VeteranReward : IDataObject
    {
		private const string MODULE = "VeteranReward";
		public int Id;
		public uint RequiredSubDays;
		public uint ItemGID;
		public uint ItemQuantity;
    }
}
