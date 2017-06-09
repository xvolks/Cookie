

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("LegendaryTreasureHunts")]
    public class LegendaryTreasureHunt : IDataObject
    {
        public const String MODULE = "LegendaryTreasureHunts";
        public uint Id;
        public uint NameId;
        public uint Level;
        public uint ChestId;
        public uint MonsterId;
        public uint MapItemId;
        public float XpRatio;
    }
}