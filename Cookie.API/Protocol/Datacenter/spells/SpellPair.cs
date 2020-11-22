using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellPair")]
    public class SpellPair : IDataObject
    {
		private const string MODULE = "SpellPair";
		public int Id;
		public int NameId;
		public int DescriptionId;
		public int IconId;
    }
}
