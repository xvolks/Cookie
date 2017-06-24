// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapPositions")]
    public class MapPosition : IDataObject
    {
        public const string MODULE = "MapPositions";
        public int Capabilities;
        public bool HasPriorityOnWorldmap;
        public int Id;
        public bool IsUnderWater;
        public int NameId;
        public bool Outdoor;
        public List<List<int>> Playlists;
        public int PosX;
        public int PosY;
        public bool ShowNameOnFingerpost;
        public List<AmbientSound> Sounds;
        public int SubAreaId;
        public int WorldMap;
    }
}