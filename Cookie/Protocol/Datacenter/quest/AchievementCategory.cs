

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AchievementCategories")]
    public class AchievementCategory : IDataObject
    {
        public const String MODULE = "AchievementCategories";
        public uint Id;
        public uint NameId;
        public uint ParentId;
        public String Icon;
        public uint Order;
        public String Color;
        public List<uint> AchievementIds;
    }
}