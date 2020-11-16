using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ItemSet")]
    public class ItemSet : IDataObject
    {
		private const string MODULE = "ItemSet";
		public int Id;
		public List<uint> Items;
		public int NameId;
		public bool BonusIsSecret;
		public List<List<EffectInstance>> Effects;
    }
}
