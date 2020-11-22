

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpellVariants")]
    public class SpellVariant : IDataObject
    {
        public const String MODULE = "SpellVariants";
        public int Id;
        public int BreedId;
        public List<int> spellIds;
    }
}