using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ItemType")]
    public class ItemType : IDataObject
    {
		private const string MODULE = "ItemType";
		public int Id;
		public int NameId;
		public int SuperTypeId;
		public int CategoryId;
		public bool IsInEncyclopedia;
		public bool Plural;
		public int Gender;
		public string RawZone;
		public bool Mimickable;
		public int CraftXpRatio;
		public int EvolutiveTypeId;
    }
}
