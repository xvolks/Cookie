using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Dungeon")]
    public class Dungeon : IDataObject
    {
		private const string MODULE = "Dungeon";
		public int Id;
		public int NameId;
		public int OptimalPlayerLevel;
		public List<double> MapIds;
		public double EntranceMapId;
		public double ExitMapId;
		public List<uint> CroupiersItemIds;
		public List<uint> CroupiersPrice;
    }
}
