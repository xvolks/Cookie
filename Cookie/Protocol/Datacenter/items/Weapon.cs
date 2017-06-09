

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Weapon")]
    public class Weapon : Item
    {
        public int ApCost;
        public int MinRange;
        public int Range;
        public uint MaxCastPerTurn;
        public Boolean CastInLine;
        public Boolean CastInDiagonal;
        public Boolean CastTestLos;
        public int CriticalHitProbability;
        public int CriticalHitBonus;
        public int CriticalFailureProbability;
    }
}