// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellStates")]
    public class SpellState : IDataObject
    {
        public const string MODULE = "SpellStates";
        public bool CantBeMoved;
        public bool CantBePushed;
        public bool CantDealDamage;
        public bool CantSwitchPosition;
        public List<int> EffectsIds;
        public string Icon = "";
        public int IconVisibilityMask;
        public int Id;
        public bool Incurable;
        public bool Invulnerable;
        public bool InvulnerableMelee;
        public bool InvulnerableRange;
        public bool IsSilent;
        public uint NameId;
        public bool PreventsFight;
        public bool PreventsSpellCast;
    }
}