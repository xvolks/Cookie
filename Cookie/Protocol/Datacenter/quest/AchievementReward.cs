

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AchievementRewards")]
    public class AchievementReward : IDataObject
    {
        public const String MODULE = "AchievementRewards";
        public uint Id;
        public uint AchievementId;
        public int LevelMin;
        public int LevelMax;
        public List<uint> ItemsReward;
        public List<uint> ItemsQuantityReward;
        public List<uint> EmotesReward;
        public List<uint> SpellsReward;
        public List<uint> TitlesReward;
        public List<uint> OrnamentsReward;
    }
}