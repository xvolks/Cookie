

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("QuestSteps")]
    public class QuestStep : IDataObject
    {
        public const String MODULE = "QuestSteps";
        public uint Id;
        public uint QuestId;
        public uint NameId;
        public uint DescriptionId;
        public int DialogId;
        public uint OptimalLevel;
        public float Duration;
        public Boolean KamasScaleWithPlayerLevel;
        public float KamasRatio;
        public float XpRatio;
        public List<uint> ObjectiveIds;
        public List<uint> RewardsIds;
    }
}