// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestStepRewards")]
    public class QuestStepRewards : IDataObject
    {
        public const string MODULE = "QuestStepRewards";
        public List<uint> EmotesReward;
        public uint Id;
        public List<List<uint>> ItemsReward;
        public List<uint> JobsReward;
        public int LevelMax;
        public int LevelMin;
        public List<uint> SpellsReward;
        public uint StepId;
    }
}