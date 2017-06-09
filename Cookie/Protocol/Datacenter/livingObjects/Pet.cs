

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Pets")]
    public class Pet : IDataObject
    {
        public const String MODULE = "Pets";
        public int Id;
        public List<int> FoodItems;
        public List<int> FoodTypes;
        public int MinDurationBeforeMeal;
        public int MaxDurationBeforeMeal;
        public List<EffectInstance> PossibleEffects;
    }
}