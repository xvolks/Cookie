// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterRaces")]
    public class MonsterRace : IDataObject
    {
        public const string MODULE = "MonsterRaces";
        public int Id;
        public List<uint> Monsters;
        public uint NameId;
        public int SuperRaceId;
    }
}