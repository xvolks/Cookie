using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EvolutiveEffect")]
    public class EvolutiveEffect : IDataObject
    {
		private const string MODULE = "EvolutiveEffect";
		public int Id;
		public int ActionId;
		public int TargetId;
		public List<List<double>> ProgressionPerLevelRange;
    }
}
