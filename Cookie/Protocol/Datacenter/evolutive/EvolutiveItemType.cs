

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("EvolutiveItemTypes")]
    public class EvolutiveItemType : IDataObject
    {
        public const String MODULE = "EvolutiveItemTypes";
        public uint Id;
        public int MaxLevel;
        public double ExperienceBoost;
        public List<int> ExperienceByLevel;
    }
}