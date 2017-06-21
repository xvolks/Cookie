using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("RankNames")]
    public class RankName : IDataObject
    {
        public const string MODULE = "RankNames";
        public int Id;
        public uint NameId;
        public int Order;
    }
}