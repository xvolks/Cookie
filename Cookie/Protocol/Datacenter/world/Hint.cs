

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Hints")]
    public class Hint : IDataObject
    {
        public const String MODULE = "Hints";
        public int Id;
        public uint Gfx;
        public uint NameId;
        public uint MapId;
        public uint RealMapId;
        public int X;
        public int Y;
        public Boolean Outdoor;
        public int SubareaId;
        public int WorldMapId;
        public uint Level;
        public uint CategoryId;
    }
}