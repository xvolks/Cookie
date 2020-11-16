using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ArenaLeagueReward")]
    public class ArenaLeagueReward : IDataObject
    {
		private const string MODULE = "ArenaLeagueReward";
		public int Id;
		public int SeasonId;
		public int LeagueId;
		public List<uint> TitlesRewards;
		public bool EndSeasonRewards;
    }
}
