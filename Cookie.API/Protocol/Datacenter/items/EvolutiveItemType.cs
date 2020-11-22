using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EvolutiveItemType")]
    public class EvolutiveItemType : IDataObject
    {
		private const string MODULE = "EvolutiveItemType";
		public int Id;
		public int MaxLevel;
		public double ExperienceBoost;
		public List<int> ExperienceByLevel;
    }
}
