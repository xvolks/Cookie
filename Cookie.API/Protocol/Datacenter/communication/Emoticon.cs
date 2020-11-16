using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Emoticon")]
    public class Emoticon : IDataObject
    {
		private const string MODULE = "Emoticon";
		public int Id;
		public int NameId;
		public int ShortcutId;
		public uint Order;
		public string DefaultAnim;
		public bool Persistancy;
		public bool Eightdirections;
		public bool Aura;
		public List<string> Anims;
		public uint Cooldown;
		public uint Duration;
		public uint Weight;
		public uint SpellLevelId;
    }
}
