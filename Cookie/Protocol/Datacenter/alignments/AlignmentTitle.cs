using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AlignmentTitles")]
    public class AlignmentTitle : IDataObject
    {
        public const String MODULE = "AlignmentTitles";
        public int SideId;
        public List<int> NamesId;
        public List<int> ShortsId;
    }
}