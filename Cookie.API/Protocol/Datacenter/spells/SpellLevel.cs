using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellLevel")]
    public class SpellLevel : IDataObject
    {
		private const string MODULE = "SpellLevel";
		public int Id;
		public int SpellId;
		public int Grade;
		public int SpellBreed;
		public int ApCost;
		public int MinRange;
		public int Range;
		public bool CastInLine;
		public bool CastInDiagonal;
		public bool CastTestLos;
		public int CriticalHitProbability;
		public bool NeedFreeCell;
		public bool NeedTakenCell;
		public bool NeedFreeTrapCell;
		public bool RangeCanBeBoosted;
		public int MaxStack;
		public int MaxCastPerTurn;
		public int MaxCastPerTarget;
		public int MinCastInterval;
		public int InitialCooldown;
		public int GlobalCooldown;
		public int MinPlayerLevel;
		public bool HideEffects;
		public bool Hidden;
		public bool PlayAnimation;
		public List<int> StatesRequired;
		public List<int> StatesAuthorized;
		public List<int> StatesForbidden;
		public List<EffectInstanceDice> Effects;
		public List<EffectInstanceDice> CriticalEffect;
		public List<string> AdditionalEffectsZones;
    }
}
