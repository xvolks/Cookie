using Cookie.Gamedata.D2o;
using System;

namespace Cookie.Datacenter
{
    [D2oClass("RankNames")]
    public class RankName : IDataObject
    {
        public const String MODULE = "RankNames";
        public int Id;
        public uint NameId;
        public int Order;
    }
}