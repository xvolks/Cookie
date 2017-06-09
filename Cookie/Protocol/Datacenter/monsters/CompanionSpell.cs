

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("CompanionSpells")]
    public class CompanionSpell : IDataObject
    {
        public const String MODULE = "CompanionSpells";
        public int Id;
        public int SpellId;
        public int CompanionId;
        public String GradeByLevel;
    }
}