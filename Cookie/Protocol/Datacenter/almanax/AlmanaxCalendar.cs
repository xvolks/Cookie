

// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AlmanaxCalendars")]
    public class AlmanaxCalendar : IDataObject
    {
        public const String MODULE = "AlmanaxCalendars";
        public int Id;
        public uint NameId;
        public uint DescId;
        public int NpcId;
        public List<int> BonusesIds;
    }
}