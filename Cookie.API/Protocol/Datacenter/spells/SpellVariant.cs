using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellVariant")]
    public class SpellVariant : IDataObject
    {
		private const string MODULE = "SpellVariant";
		public int Id;
		public int BreedId;
		public List<uint> SpellIds;
    }
}
