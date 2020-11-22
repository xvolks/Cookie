// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ArenaLeagues")]
    public class ArenaLeague : IDataObject
    {
        public const String MODULE = "ArenaLeagues";
        public int Id;
        public uint NameId;
        public uint OrnamentId;
        public string Icon;
        public string Illus;
        public Boolean IsLastLeague;
    }
}