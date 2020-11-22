using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Pet")]
    public class Pet : IDataObject
    {
		private const string MODULE = "Pet";
		public int Id;
		public List<int> FoodItems;
		public List<int> FoodTypes;
		public int MinDurationBeforeMeal;
		public int MaxDurationBeforeMeal;
		public List<EffectInstance> PossibleEffects;
    }
}
