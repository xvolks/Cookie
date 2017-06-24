// Generated on 12/06/2016 11:35:49

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentRank")]
    public class AlignmentRank : IDataObject
    {
        public const string MODULE = "AlignmentRank";
        public uint DescriptionId;
        public List<int> Gifts;
        public int Id;
        public int MinimumAlignment;
        public uint NameId;
        public int ObjectsStolen;
        public uint OrderId;
    }
}