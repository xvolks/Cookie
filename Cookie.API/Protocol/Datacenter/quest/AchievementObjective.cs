// Generated on 12/06/2016 11:35:51

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("AchievementObjectives")]
    public class AchievementObjective : IDataObject
    {
        public const string MODULE = "AchievementObjectives";
        public uint AchievementId;
        public string Criterion;
        public uint Id;
        public uint NameId;
        public uint Order;
    }
}