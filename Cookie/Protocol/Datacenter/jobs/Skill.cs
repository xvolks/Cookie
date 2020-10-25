

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Skills")]
    public class Skill : IDataObject
    {
        public const String MODULE = "Skills";
        public int Id;
        public uint NameId;
        public int ParentJobId;
        public Boolean IsForgemagus;
        public List<int> ModifiableItemTypeIds;
        public int GatheredRessourceItem;
        public List<int> CraftableItemIds;
        public int InteractiveId;
        public String UseAnimation;
        public int Cursor;
        public int ElementActionId;
        public Boolean AvailableInHouse;
        public uint LevelMin;
        public Boolean ClientDisplay;
        public int Range;
        public Boolean UseRangeInClient;
    }
}