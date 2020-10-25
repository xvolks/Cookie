

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpellStates")]
    public class SpellState : IDataObject
    {
        public const String MODULE = "SpellStates";
        public int Id;
        public uint NameId;
        public Boolean PreventsSpellCast;
        public Boolean PreventsFight;
        public Boolean IsSilent;
        public Boolean CantDealDamage;
        public Boolean Invulnerable;
        public Boolean Incurable;
        public Boolean CantBeMoved;
        public Boolean CantBePushed;
        public Boolean CantSwitchPosition;
        public List<int> EffectsIds;
        public String Icon = "";
        public int IconVisibilityMask;
        public Boolean InvulnerableMelee;
        public Boolean InvulnerableRange;
        public Boolean CantTackle;
        public Boolean CantBeTackled;
    }
}