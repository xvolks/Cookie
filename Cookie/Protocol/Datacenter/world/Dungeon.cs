

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Dungeons")]
    public class Dungeon : IDataObject
    {
        public const String MODULE = "Dungeons";
        public int Id;
        public uint NameId;
        public int OptimalPlayerLevel;
        public List<int> MapIds;
        public int EntranceMapId;
        public int ExitMapId;
    }
}