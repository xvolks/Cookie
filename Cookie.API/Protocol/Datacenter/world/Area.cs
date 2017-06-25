// Generated on 12/06/2016 11:35:52

using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Areas")]
    public class Area : IDataObject
    {
        public const string MODULE = "Areas";
        public Rectangle Bounds;
        public bool ContainHouses;
        public bool ContainPaddocks;
        public bool HasWorldMap;
        public int Id;
        public uint NameId;
        public int SuperAreaId;
        public uint WorldmapId;
    }
}