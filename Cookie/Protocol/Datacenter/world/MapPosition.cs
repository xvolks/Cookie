

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MapPositions")]
    public class MapPosition : IDataObject
    {
        public const String MODULE = "MapPositions";
        public int Id;
        public int PosX;
        public int PosY;
        public Boolean Outdoor;
        public int Capabilities;
        public int NameId;
        public Boolean ShowNameOnFingerpost;
        public List<AmbientSound> Sounds;
        public List<List<int>> Playlists;
        public int SubAreaId;
        public int WorldMap;
        public Boolean HasPriorityOnWorldmap;
        public Boolean IsUnderWater;
        public Boolean AllowPrism;
        public Boolean IsTransition;
        public uint TacticalModeTemplateId;
        public Boolean HasPublicPaddock;
    }
}