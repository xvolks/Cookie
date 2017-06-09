

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;
using Cookie.Datacenter;
using Cookie.GameData.D2O;

namespace Cookie.Datacenter
{
    [D2oClass("Areas")]
    public class Area : IDataObject
    {
        public const String MODULE = "Areas";
        public int Id;
        public uint NameId;
        public int SuperAreaId;
        public Boolean ContainHouses;
        public Boolean ContainPaddocks;
        public Rectangle Bounds;
        public uint WorldmapId;
        public Boolean HasWorldMap;
    }
}