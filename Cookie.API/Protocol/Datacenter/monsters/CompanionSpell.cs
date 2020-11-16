using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CompanionSpell")]
    public class CompanionSpell : IDataObject
    {
		private const string MODULE = "CompanionSpell";
		public int Id;
		public int SpellId;
		public int CompanionId;
		public string GradeByLevel;
    }
}
