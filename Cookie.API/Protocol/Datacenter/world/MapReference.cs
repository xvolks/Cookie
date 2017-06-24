using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapReferences")]
    public class MapReference : IDataObject
    {
        public const string MODULE = "MapReferences";
        public int CellId;
        public int Id;
        public uint MapId;
    }
}