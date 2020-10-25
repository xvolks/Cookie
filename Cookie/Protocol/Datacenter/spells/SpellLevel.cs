

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpellLevels")]
    public class SpellLevel : IDataObject
    {
        public const String MODULE = "SpellLevels";
        public uint Id;
        public uint SpellId;
        public uint Grade;
        public uint SpellBreed;
        public uint ApCost;
        public uint MinRange;
        public uint Range;
        public Boolean CastInLine;
        public Boolean CastInDiagonal;
        public Boolean CastTestLos;
        public uint CriticalHitProbability;
        public Boolean NeedFreeCell;
        public Boolean NeedTakenCell;
        public Boolean NeedFreeTrapCell;
        public Boolean RangeCanBeBoosted;
        public int MaxStack;
        public uint MaxCastPerTurn;
        public uint MaxCastPerTarget;
        public uint MinCastInterval;
        public uint InitialCooldown;
        public int GlobalCooldown;
        public uint MinPlayerLevel;
        public Boolean HideEffects;
        public Boolean Hidden;
        public Boolean PlayAnimation;
        public List<int> StatesRequired;
        public List<int> StatesForbidden;
        public List<EffectInstanceDice> Effects;
        public List<EffectInstanceDice> CriticalEffect;
        public List<int> StatesAuthorized;
        public List<int> AdditionalEffectsZones;
    }
}