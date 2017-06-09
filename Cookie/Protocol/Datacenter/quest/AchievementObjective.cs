

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AchievementObjectives")]
    public class AchievementObjective : IDataObject
    {
        public const String MODULE = "AchievementObjectives";
        public uint Id;
        public uint AchievementId;
        public uint Order;
        public uint NameId;
        public String Criterion;
    }
}