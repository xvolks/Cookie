// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Dungeons")]
    public class Dungeon : IDataObject
    {
        public const string MODULE = "Dungeons";
        public int EntranceMapId;
        public int ExitMapId;
        public int Id;
        public List<int> MapIds;
        public uint NameId;
        public int OptimalPlayerLevel;
    }
}