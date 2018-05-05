// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpellLevels")]
    public class SpellLevel : IDataObject
    {
        public const string MODULE = "SpellLevels";
        public uint ApCost;
        public bool CastInDiagonal;
        public bool CastInLine;
        public bool CastTestLos;
        public List<EffectInstanceDice> CriticalEffect;
        public uint CriticalHitProbability;
        public List<EffectInstanceDice> Effects;
        public int GlobalCooldown;
        public uint Grade;
        public bool Hidden;
        public bool HideEffects;
        public uint Id;
        public uint InitialCooldown;
        public uint MaxCastPerTarget;
        public uint MaxCastPerTurn;
        public int MaxStack;
        public uint MinCastInterval;
        public uint MinPlayerLevel;
        public uint MinRange;
        public bool NeedFreeCell;
        public bool NeedFreeTrapCell;
        public bool NeedTakenCell;
        public bool PlayAnimation;
        public uint Range;
        public bool RangeCanBeBoosted;
        public uint SpellBreed;
        public uint SpellId;
        public List<int> StatesForbidden;
        public List<int> StatesRequired;
    }
}