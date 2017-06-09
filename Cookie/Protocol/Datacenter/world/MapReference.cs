using Cookie.Gamedata.D2o;
using System;

namespace Cookie.Datacenter
{
    [D2oClass("MapReferences")]
    public class MapReference : IDataObject
    {
        public const String MODULE = "MapReferences";
        public int Id;
        public uint MapId;
        public int CellId;
    }
}