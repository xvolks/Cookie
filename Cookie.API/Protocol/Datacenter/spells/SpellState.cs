using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellState")]
    public class SpellState : IDataObject
    {
		private const string MODULE = "SpellState";
		public int Id;
		public int NameId;
		public bool PreventsSpellCast;
		public bool PreventsFight;
		public bool IsSilent;
		public bool CantBeMoved;
		public bool CantBePushed;
		public bool CantDealDamage;
		public bool Invulnerable;
		public bool CantSwitchPosition;
		public bool Incurable;
		public List<int> EffectsIds;
		public string Icon;
		public int IconVisibilityMask;
		public bool InvulnerableMelee;
		public bool InvulnerableRange;
		public bool CantTackle;
		public bool CantBeTackled;
    }
}
