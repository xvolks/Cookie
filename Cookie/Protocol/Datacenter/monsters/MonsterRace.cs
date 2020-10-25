

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MonsterRaces")]
    public class MonsterRace : IDataObject
    {
        public const String MODULE = "MonsterRaces";
        public int Id;
        public int SuperRaceId;
        public uint NameId;
        public List<uint> Monsters;
        public int AggressiveZoneSize;
        public int AggressiveLevelDiff;
        public String AggressiveImmunityCriterion;
        public String AggressiveAttackDelay;
    }
}