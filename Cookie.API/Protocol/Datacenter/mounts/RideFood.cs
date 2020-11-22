using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("RideFood")]
    public class RideFood : IDataObject
    {
		private const string MODULE = "RideFood";
		public int Gid;
		public int TypeId;
		public int FamilyId;
    }
}
