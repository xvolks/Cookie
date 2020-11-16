using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CharacteristicCategory")]
    public class CharacteristicCategory : IDataObject
    {
		private const string MODULE = "CharacteristicCategory";
		public int Id;
		public int NameId;
		public int Order;
		public List<uint> CharacteristicIds;
    }
}
