// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("QuestSteps")]
    public class QuestStep : IDataObject
    {
        public const string MODULE = "QuestSteps";
        public uint DescriptionId;
        public int DialogId;
        public float Duration;
        public uint Id;
        public float KamasRatio;
        public bool KamasScaleWithPlayerLevel;
        public uint NameId;
        public List<uint> ObjectiveIds;
        public uint OptimalLevel;
        public uint QuestId;
        public List<uint> RewardsIds;
        public float XpRatio;
    }
}