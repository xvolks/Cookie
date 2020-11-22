using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SmileyPack")]
    public class SmileyPack : IDataObject
    {
		private const string MODULE = "SmileyPack";
		public int Id;
		public int NameId;
		public int Order;
		public List<uint> Smileys;
    }
}
