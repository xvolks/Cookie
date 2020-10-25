

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("QuestStepRewards")]
    public class QuestStepRewards : IDataObject
    {
        public const String MODULE = "QuestStepRewards";
        public uint Id;
        public uint StepId;
        public int LevelMin;
        public int LevelMax;
        public List<List<uint>> ItemsReward;
        public List<uint> EmotesReward;
        public List<uint> JobsReward;
        public List<uint> SpellsReward;
        public double KamasRatio;
        public double ExperienceRatio;
        public Boolean KamasScaleWithPlayerLevel;
        public List<int> TitlesReward;
    }
}