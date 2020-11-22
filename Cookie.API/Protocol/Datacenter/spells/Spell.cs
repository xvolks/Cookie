using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Spell")]
    public class Spell : IDataObject
    {
		private const string MODULE = "Spell";
		public int Id;
		public int NameId;
		public int DescriptionId;
		public int TypeId;
		public int Order;
		public string ScriptParams;
		public string ScriptParamsCritical;
		public int ScriptId;
		public int ScriptIdCritical;
		public int IconId;
		public List<uint> SpellLevels;
		public bool Verbosecast;
		public string Defaultzone;
		public bool BypassSummoningLimit;
		public bool CanAlwaysTriggerSpells;
    }
}
