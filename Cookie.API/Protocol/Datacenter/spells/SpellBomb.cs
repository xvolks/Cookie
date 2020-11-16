using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellBomb")]
    public class SpellBomb : IDataObject
    {
		private const string MODULE = "SpellBomb";
		public int Id;
		public int ChainReactionSpellId;
		public int ExplodSpellId;
		public int WallId;
		public int InstantSpellId;
		public int ComboCoeff;
    }
}
