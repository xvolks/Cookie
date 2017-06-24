// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Pets")]
    public class Pet : IDataObject
    {
        public const string MODULE = "Pets";
        public List<int> FoodItems;
        public List<int> FoodTypes;
        public int Id;
        public int MaxDurationBeforeMeal;
        public int MinDurationBeforeMeal;
        public List<EffectInstance> PossibleEffects;
    }
}