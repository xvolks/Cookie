using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CompanionCharacteristic")]
    public class CompanionCharacteristic : IDataObject
    {
		private const string MODULE = "CompanionCharacteristic";
		public int Id;
		public int CaracId;
		public int CompanionId;
		public int Order;
		public List<List<double>> StatPerLevelRange;
    }
}
