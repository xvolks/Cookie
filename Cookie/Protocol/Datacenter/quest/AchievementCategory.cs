// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AchievementCategories")]
    public class AchievementCategory : IDataObject
    {
        public const string MODULE = "AchievementCategories";
        public List<uint> AchievementIds;
        public string Color;
        public string Icon;
        public uint Id;
        public uint NameId;
        public uint Order;
        public uint ParentId;
    }
}