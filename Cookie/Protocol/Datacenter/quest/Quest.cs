

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Quests")]
    public class Quest : IDataObject
    {
        public const String MODULE = "Quests";
        public uint Id;
        public uint NameId;
        public List<uint> StepIds;
        public uint CategoryId;
        public uint RepeatType;
        public uint RepeatLimit;
        public Boolean IsDungeonQuest;
        public uint LevelMin;
        public uint LevelMax;
        public Boolean IsPartyQuest;
        public String StartCriterion;
        public Boolean Followable;
    }
}