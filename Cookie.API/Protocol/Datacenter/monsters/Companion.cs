using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Companion")]
    public class Companion : IDataObject
    {
		private const string MODULE = "Companion";
		public int Id;
		public int NameId;
		public string Look;
		public bool WebDisplay;
		public int DescriptionId;
		public int StartingSpellLevelId;
		public int AssetId;
		public List<uint> Characteristics;
		public List<uint> Spells;
		public int CreatureBoneId;
    }
}
