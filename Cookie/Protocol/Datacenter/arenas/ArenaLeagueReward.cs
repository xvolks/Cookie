// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ArenaLeagueRewards")]
    public class ArenaLeagueReward : IDataObject
    {
        public const String MODULE = "ArenaLeagueRewards";
        public int Id;
        public uint SeasonId;
        public uint LeagueId;
        public List<int> TitlesRewards;
        public Boolean EndSeasonRewards;
    }
}