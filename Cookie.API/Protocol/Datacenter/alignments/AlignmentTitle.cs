using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentTitles")]
    public class AlignmentTitle : IDataObject
    {
        public const string MODULE = "AlignmentTitles";
        public List<int> NamesId;
        public List<int> ShortsId;
        public int SideId;
    }
}