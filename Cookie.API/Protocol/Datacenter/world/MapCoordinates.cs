// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapCoordinates")]
    public class MapCoordinates : IDataObject
    {
        public const string MODULE = "MapCoordinates";
        public uint CompressedCoords;
        public List<int> MapIds;
    }
}