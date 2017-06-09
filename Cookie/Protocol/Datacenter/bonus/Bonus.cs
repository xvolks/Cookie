

// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Bonuses")]
    public class Bonus : IDataObject
    {
        public const String MODULE = "Bonuses";
        public int Id;
        public uint Type;
        public int Amount;
        public List<int> CriterionsIds;
    }
}