

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpellBombs")]
    public class SpellBomb : IDataObject
    {
        public const String MODULE = "SpellBombs";
        public int Id;
        public int ChainReactionSpellId;
        public int ExplodSpellId;
        public int WallId;
        public int InstantSpellId;
        public int ComboCoeff;
    }
}