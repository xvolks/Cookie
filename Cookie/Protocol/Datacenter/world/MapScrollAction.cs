

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MapScrollActions")]
    public class MapScrollAction : IDataObject
    {
        public const String MODULE = "MapScrollActions";
        public int Id;
        public Boolean RightExists;
        public Boolean BottomExists;
        public Boolean LeftExists;
        public Boolean TopExists;
        public int RightMapId;
        public int BottomMapId;
        public int LeftMapId;
        public int TopMapId;
    }
}