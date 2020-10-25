

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("EvolutiveEffects")]
    public class EvolutiveEffect : IDataObject
    {
        public const String MODULE = "EvolutiveEffects";
        public uint Id;
        public int ActionId;
        public int TargetId;
        public List<double> ProgressionPerLevelRange;
    }
}