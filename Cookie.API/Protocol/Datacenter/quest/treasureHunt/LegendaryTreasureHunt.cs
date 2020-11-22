using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("LegendaryTreasureHunt")]
    public class LegendaryTreasureHunt : IDataObject
    {
		private const string MODULE = "LegendaryTreasureHunt";
		public int Id;
		public int NameId;
		public int Level;
		public uint ChestId;
		public uint MonsterId;
		public uint MapItemId;
		public double XpRatio;
    }
}
