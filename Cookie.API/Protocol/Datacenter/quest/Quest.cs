// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Quests")]
    public class Quest : IDataObject
    {
        public const string MODULE = "Quests";
        public uint CategoryId;
        public uint Id;
        public bool IsDungeonQuest;
        public bool IsPartyQuest;
        public uint LevelMax;
        public uint LevelMin;
        public uint NameId;
        public uint RepeatLimit;
        public uint RepeatType;
        public string StartCriterion;
        public List<uint> StepIds;
    }
}