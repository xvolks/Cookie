

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SuperAreas")]
    public class SuperArea : IDataObject
    {
        public const String MODULE = "SuperAreas";
        public int Id;
        public uint NameId;
        public uint WorldmapId;
        public Boolean HasWorldMap;
    }
}